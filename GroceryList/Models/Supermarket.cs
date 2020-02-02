using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    public class Supermarket : BaseModel
    {
        public Supermarket()
        {
        }

        [Required]
        [DataMember]
        public string Description { get; set; }

        public IList<ShoppingList> ShoppingLists { get; set; }

        public IList<SupermarketCategories> SupermarketCategories { get; set; }
    }
}
