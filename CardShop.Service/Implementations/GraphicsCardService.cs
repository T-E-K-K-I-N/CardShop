using CardShop.DAL.Interfaces;
using CardShop.Domain.Enum;
using CardShop.Domain.Models;
using CardShop.Domain.Responce;
using CardShop.Domain.ViewModels.GraphicsCard;
using CardShop.Service.Interfaces;
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
        public async Task<IBaseResponse<GraphicsCard>> GetGraphicsCard(int id)
        {
            var baseResponse = new BaseResponse<GraphicsCard>();
            try
            {
                var graphicsCard = await _graphicsCardRepository.Get(id);
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
                    Description = $"[GetGraphicsCard] : {ex.Message}"
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
                var graphicsCard = await _graphicsCardRepository.GetByTitleAsync(title);
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
        public async Task<IBaseResponse<IEnumerable<GraphicsCard>>> GetGraphicsCards()
        {
            var baseResponse = new BaseResponse<IEnumerable<GraphicsCard>>();
            try
            {
                var graphicsCards =  await _graphicsCardRepository.Select();

                if (graphicsCards.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound;
                    return baseResponse;
                }

                baseResponse.Data = graphicsCards;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GraphicsCard>>()
                {
                    Description = $"[GetGraphicsCards] : {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Создает объект "Видеокарта" исходя из предложенной модели
        /// </summary>
        public async Task<IBaseResponse<GraphicsCardViewModel>> CreateGraphicsCard(GraphicsCardViewModel graphicsCardViewModel)
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
                    Price = graphicsCardViewModel.Price
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
                var graphicsCard =  await _graphicsCardRepository.Get(id);
                if (graphicsCard == null)
                {
                    baseResponse.Description = "Видеокарта не найдена";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.GraphicsCardNotFound;
                    return baseResponse;
                }

                await _graphicsCardRepository.Delete(graphicsCard);
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;
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
                var graphicsCard = await _graphicsCardRepository.Get(id);
                if (graphicsCard == null)
                {
                    baseResponse.StatusCode = StatusCode.GraphicsCardNotFound;
                    baseResponse.Description = "Видеокарта не найдена";
                    return baseResponse;
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

                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {

                return new BaseResponse<GraphicsCard>()
                {
                    Description = $"[Edit] : {ex.Message}"
                };
            }
        }
    }
}
