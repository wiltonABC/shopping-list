using System;
using System.Threading.Tasks;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public class SupermarketCategoriesRepository : BaseRepository<SupermarketCategories>, ISupermarketCategoriesRepository
    {
        public SupermarketCategoriesRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<SupermarketCategories> Add(SupermarketCategories supermarketCategories)
        {
            await dbSet.AddAsync(supermarketCategories);
            await applicationContext.SaveChangesAsync();

            return supermarketCategories;
        }

        public async Task<SupermarketCategories> GetSupermarketCategories(int id)
        {
            return await dbSet.Include(c => c.Category)
                .Include(c => c.Supermarket).FirstAsync(c => c.Id == id);
        }

        public async Task RemoveSupermarketCategory(int id)
        {
            dbSet.Remove(new SupermarketCategories { Id = id });
            await applicationContext.SaveChangesAsync();
        }
    }
}
