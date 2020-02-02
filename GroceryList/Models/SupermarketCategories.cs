using System;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    public class  SupermarketCategories : BaseModel
    {
        public SupermarketCategories()
        {
        }

        [DataMember]
        public Supermarket Supermarket { get; set; }

        [DataMember]
        public int SupermarketId { get; set; }

        [DataMember]
        public Category Category { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public int Order { get; set; }
    }
}
