using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroceryList.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime? CreationDate { get; set; }
    }
}