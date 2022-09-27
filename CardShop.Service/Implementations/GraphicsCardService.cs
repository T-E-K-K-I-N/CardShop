using CardShop.DAL.Interfaces;
using CardShop.Domain.Models;
using CardShop.Domain.Responce;
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

        public async Task<IBaseResponse<IEnumerable<GraphicsCard>>> GetGraphicsCards()
        {
            var baseResponse = new BaseResponse<IEnumerable<GraphicsCard>>();
            try
            {
                var graphicsCards =  await _graphicsCardRepository.Select();

                if (graphicsCards.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
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
    }
}
