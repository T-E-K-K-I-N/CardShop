using CardShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.DAL.Interfaces
{
    public interface IGraphicsCardRepository: IBaseRepository<GraphicsCard>
    {
        Task<GraphicsCard> GetByTitleAsync(string title);

    }
}
