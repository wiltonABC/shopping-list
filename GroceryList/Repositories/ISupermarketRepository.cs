using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.Repositories
{
    public interface ISupermarketRepository
    {

        Task<IList<Supermarket>> GetSupermarkets();
        Task<Supermarket> AddSupermarket();
        Task<Supermarket> GetSupermarket(int id);
        Task<Supermarket> GetSupermarketWithCategories(int id);
        Task UpdateSupermarket(Supermarket supermarket);
    }
}
