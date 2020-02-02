using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }

        public async Task<IList<ShoppingList>> GetShoppingLists()
        {
            return await dbSet.ToListAsync();
        }
    }
}
