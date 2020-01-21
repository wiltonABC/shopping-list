using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task AddProduct(Product product)
        {
            await dbSet.AddAsync(product);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await dbSet.Include(product => product.Category).ToListAsync();
        }

        public async Task RemoveProduct(int id)
        {
            var product = new Product() { Id = id };

            dbSet.Remove(product);

            await applicationContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            dbSet.Update(product);

            await applicationContext.SaveChangesAsync();
        }
    }
}
