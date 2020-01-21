using System;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    public class ListItem : BaseModel
    {

        [DataMember]
        public ShoppingList ShoppingList { get; set; }

        [DataMember]
        public int ShoppingListId { get; set; }

        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public bool Checked { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public decimal SubTotal => Quantity * Price;

        public ListItem()
        {
        }
    }
}
