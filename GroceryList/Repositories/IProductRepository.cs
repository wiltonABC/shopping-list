using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.Repositories
{
    public interface IProductRepository
    {

        Task<IList<Product>> GetProducts();
        Task AddProduct(Product product);
        Task RemoveProduct(int id);
        Task<Product> GetProduct(int id);
        Task UpdateProduct(Product product);

    }
}
