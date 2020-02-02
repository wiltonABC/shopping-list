using System;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.Repositories
{
    public interface ISupermarketCategoriesRepository
    {

        Task<SupermarketCategories> Add(SupermarketCategories supermarketCategories);
        Task<SupermarketCategories> GetSupermarketCategories(int id);
        Task RemoveSupermarketCategory(int id);
    }
}
