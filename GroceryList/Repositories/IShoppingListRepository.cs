using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.Repositories
{
    public interface IShoppingListRepository
    {
        Task<IList<ShoppingList>> GetShoppingLists();
    }
}
