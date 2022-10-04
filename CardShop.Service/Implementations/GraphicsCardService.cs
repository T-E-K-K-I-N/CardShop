using CardShop.DAL.Interfaces;
using CardShop.Domain.Enum;
using CardShop.Domain.Extensions;
using CardShop.Domain.Models;
using CardShop.Domain.Responce;
using CardShop.Domain.ViewModels.GraphicsCard;
using CardShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Service.Implementations
{
    public class GraphicsCardService : IGraphicsCardService
    {
        private readonly IGraphicsCardRepository _graphicsCardRepository;

        public GraphicsCardService(IGraphicsCardRepository graphicsCardRepository)
        {
            _graphicsCardRepository = graphicsCardRepository;
        }

        /// <summary>
        /// Возвращает объект "Видеокарта" с указанным Id
        /// </summary>
        /// <param name="id">Id видеокарты в БД</param>
        public async Task<IBaseResponse<GraphicsCardViewModel>> GetGraphicsCard(int id)
        {
            var baseResponse = new BaseResponse<GraphicsCard>();
            try
            {
                var graphicsCard = await _graphicsCardRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (graphicsCard == null)
                {
                    return new BaseResponse<GraphicsCardViewModel>()
                    {
                        Description = "Видеокарта не найдена",
                        StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound
                    };
                }

                var data = new GraphicsCardViewModel()
                {
                    Title = graphicsCard.Title,
                    Manufacturer = graphicsCard.Manufacturer.GetDisplayName(),
                    Model = graphicsCard.Model,
                    Description = graphicsCard.Description,
                    FrequencyGPU = graphicsCard.FrequencyGPU,
                    MemoryCapacity = graphicsCard.MemoryCapacity,
                    MemoryType = graphicsCard.MemoryType,
                    FrequencyMemory = graphicsCard.FrequencyMemory,
                    Price = graphicsCard.Price,
                    Image = graphicsCard.Avatar
                };

                return new BaseResponse<GraphicsCardViewModel>()
                {
                    StatusCode = Domain.Enum.StatusCode.OK,
                    Data = data
                };

            }
            catch (Exception ex)
            { 
                return new BaseResponse<GraphicsCardViewModel>()
                {
                    Description = $"[GetGraphicsCard] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Возвращает объект "Видеокарта" с указанным названием Title
        /// </summary>
        /// <param name="title">Название видеокарты</param>
        public async Task<IBaseResponse<GraphicsCard>> GetGraphicsCardByTitle(string title)
        {
            var baseResponse = new BaseResponse<GraphicsCard>();
            try
            {
                var graphicsCard = await _graphicsCardRepository.GetAll().FirstOrDefaultAsync(x => x.Title == title);
                if (graphicsCard == null)
                {

                    baseResponse.Description = "Видеокарта не найдена";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound;
                    return baseResponse;
                }

                baseResponse.Data = graphicsCard;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<GraphicsCard>()
                {
                    Description = $"[GetGraphicsCardByTitle] : {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Возвращает всю коллекцию объектов (Видеокарт)
        /// </summary>
        public IBaseResponse<List<GraphicsCard>> GetGraphicsCards()
        {
            var baseResponse = new BaseResponse<IEnumerable<GraphicsCard>>();
            try
            {
                var graphicsCards = _graphicsCardRepository.GetAll().ToList();
                if(!graphicsCards.Any())
                {
                    return new BaseResponse<List<GraphicsCard>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound
                    };
                }
                return new BaseResponse<List<GraphicsCard>>()
                {
                    Data = graphicsCards,
                    StatusCode = Domain.Enum.StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<List<GraphicsCard>>()
                {
                    Description = $"[GetGraphicsCards] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Создает объект "Видеокарта" исходя из предложенной модели
        /// </summary>
        public async Task<IBaseResponse<GraphicsCardViewModel>> CreateGraphicsCard(GraphicsCardViewModel graphicsCardViewModel, byte[] imageData)
        {
            var baseResponse = new BaseResponse<GraphicsCardViewModel>();
            try
            {
                var graphicsCard = new GraphicsCard()
                {
                    Title = graphicsCardViewModel.Title,
                    Manufacturer = (Manufacturer)Convert.ToInt32(graphicsCardViewModel.Manufacturer),
                    Model = graphicsCardViewModel.Model,
                    Description = graphicsCardViewModel.Description,
                    FrequencyGPU = graphicsCardViewModel.FrequencyGPU,
                    MemoryCapacity = graphicsCardViewModel.MemoryCapacity,
                    MemoryType = graphicsCardViewModel.MemoryType,
                    FrequencyMemory = graphicsCardViewModel.FrequencyMemory,
                    Price = graphicsCardViewModel.Price,
                    Avatar = imageData
                };

                await _graphicsCardRepository.Create(graphicsCard);
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
            }
            catch (Exception ex)
            {
                return new BaseResponse<GraphicsCardViewModel>()
                {
                    Description = $"[CreateGraphicsCard] : {ex.Message}"
                };
            }

            return baseResponse;
        }


        /// <summary>
        /// Удаляет объект "Видеокарта" по указанному Id
        /// </summary>
        /// <param name="id">Id видеокарты в БД</param>
        public async Task<IBaseResponse<bool>> DeleteGraphicsCard (int id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var graphicsCard =  await _graphicsCardRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (graphicsCard == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Видеокарта не найдена",
                        StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound,
                        Data = false
                    };
                }

                await _graphicsCardRepository.Delete(graphicsCard);

                return new BaseResponse<bool>()
                {
                    StatusCode = Domain.Enum.StatusCode.OK,
                    Data = true
                };

                
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteGraphicsCard] : {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Изменяет объект "Видеокарта" другим объектом по указанному Id
        /// </summary>
        public async Task<IBaseResponse<GraphicsCard>> Edit(int id, GraphicsCardViewModel graphicsCardViewModel)
        {
            var baseResponse = new BaseResponse<GraphicsCard>();
            try
            {
                var graphicsCard = await _graphicsCardRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (graphicsCard == null)
                {
                    return new BaseResponse<GraphicsCard>()
                    {
                        Description = "Видеокарта не найдена",
                        StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound,
                    };
                }

                graphicsCard.Title = graphicsCardViewModel.Title;
                graphicsCard.Manufacturer = (Manufacturer)Convert.ToInt32(graphicsCardViewModel.Manufacturer);
                graphicsCard.Model = graphicsCardViewModel.Model;
                graphicsCard.Description = graphicsCardViewModel.Description;
                graphicsCard.FrequencyGPU = graphicsCardViewModel.FrequencyGPU;
                graphicsCard.MemoryCapacity = graphicsCardViewModel.MemoryCapacity;
                graphicsCard.MemoryType = graphicsCardViewModel.MemoryType;
                graphicsCard.FrequencyMemory = graphicsCardViewModel.FrequencyMemory;
                graphicsCard.Price = graphicsCardViewModel.Price;

                await _graphicsCardRepository.Update(graphicsCard);

                return new BaseResponse<GraphicsCard>()
                {
                    Data = graphicsCard,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {

                return new BaseResponse<GraphicsCard>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
