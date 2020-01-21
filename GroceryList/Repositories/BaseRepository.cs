using System;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {

        protected readonly ApplicationContext applicationContext;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            dbSet = applicationContext.Set<T>();
        }


    }
}
