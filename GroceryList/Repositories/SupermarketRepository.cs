using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public class SupermarketRepository : BaseRepository<Supermarket>, ISupermarketRepository
    {
        public SupermarketRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<Supermarket> AddSupermarket()
        {
            var supermarket = new Supermarket();
            supermarket.Description = $"New Supermarket {Guid.NewGuid()}";

            await dbSet.AddAsync(supermarket);
            await applicationContext.SaveChangesAsync();

            return supermarket;
        }

        public async Task<Supermarket> GetSupermarket(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<Supermarket> GetSupermarketWithCategories(int id)
        {
            return await dbSet.Include(s => s.SupermarketCategories)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IList<Supermarket>> GetSupermarkets()
        {
            return await dbSet.ToListAsync();
        }

        public async Task UpdateSupermarket(Supermarket supermarket)
        {
            dbSet.Update(supermarket);

            applicationContext.Entry(supermarket).Property(s => s.CreationDate)
                .IsModified = false;

            await applicationContext.SaveChangesAsync();
        }
    }
}
