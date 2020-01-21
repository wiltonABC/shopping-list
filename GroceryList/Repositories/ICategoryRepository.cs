using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.Repositories
{
    public interface ICategoryRepository
    {
        Task<IList<Category>> GetCategories();
        Task AddCategory(Category category);
        Task RemoveCategory(int id);
        Task<Category> GetCategory(int id);
        Task UpdateCategory(Category category);
    }
}
