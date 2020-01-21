using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    public class Category : BaseModel
    {
        [Required]
        [DataMember]
        public string Description { get; set; }

        public IList<Product> Products { get; set; }

        public Category()
        {

        }

        public Category(string description)
        {
            this.Description = description;
        }
    }
}
