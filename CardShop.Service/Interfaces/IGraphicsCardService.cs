using CardShop.Domain.Models;
using CardShop.Domain.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Service.Interfaces
{
    public interface IGraphicsCardService
    {
        Task<IBaseResponse<IEnumerable<GraphicsCard>>> GetGraphicsCards();
    }
}
