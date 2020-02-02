using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    public class ShoppingList : BaseModel
    {

        [Required]
        [DataMember]
        public string Description { get; set; }

        [Required]
        [DataMember]
        public DateTime ShoppingDate { get; set; }

        public IList<ListItem> Items { get; set; } = new List<ListItem>();

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public Supermarket Supermarket { get; set; }

        [DataMember]
        public int SupermarketId { get; set; }

        public ShoppingList()
        {
        }
    }
}
