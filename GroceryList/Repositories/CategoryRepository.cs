using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task AddCategory(Category category)
        {
            await dbSet.AddAsync(category);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task RemoveCategory(int id)
        {
            var category = new Category() { Id = id };
            dbSet.Remove(category);

            await applicationContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            dbSet.Update(category);
            await applicationContext.SaveChangesAsync();
        }
    }
}
