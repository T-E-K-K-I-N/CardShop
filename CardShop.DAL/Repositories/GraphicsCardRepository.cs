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
    public class GraphicsCardRepository : IGraphicsCardRepository
    {
        private readonly ApplicationDbContext _db;

        public GraphicsCardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(GraphicsCard entity)
        {
            await  _db.GraphicsCard.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(GraphicsCard entity)
        {
            _db.GraphicsCard.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task <GraphicsCard> Get(int id)
        {
            return await _db.GraphicsCard.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GraphicsCard> GetByTitleAsync(string title)
        {
            return await _db.GraphicsCard.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<List<GraphicsCard>> Select()
        {
            return await _db.GraphicsCard.ToListAsync();
        }

        public async Task<GraphicsCard> Update(GraphicsCard entity)
        {
            _db.GraphicsCard.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
