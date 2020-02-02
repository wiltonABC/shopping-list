
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    public class Product : BaseModel
    {

        [Required]
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public Category Category { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        public IList<ListItem> Items { get; set; }

        public Product()
        {
        }
    }
}
