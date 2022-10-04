using CardShop.DAL.Interfaces;
using CardShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.DAL.Repositories
{
    public class GraphicsCardRepository : IBaseRepository<GraphicsCard>
    {
        private readonly ApplicationDbContext _db;

        public GraphicsCardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(GraphicsCard entity)
        {
            await  _db.GraphicsCard.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(GraphicsCard entity)
        {
            _db.GraphicsCard.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<GraphicsCard> GetAll()
        {
            return _db.GraphicsCard;
        }


        public async Task<GraphicsCard> Update(GraphicsCard entity)
        {
            _db.GraphicsCard.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
