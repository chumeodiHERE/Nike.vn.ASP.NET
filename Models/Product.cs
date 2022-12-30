using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nike_vn.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<long> ProductGenderId { get; set; }
        public Nullable<long> ApparelId { get; set; }
        public Nullable<long> CategoryId { get; set; }

        public virtual ProductGender ProductGender { get; set; }
        public virtual Apparel Apparel { get; set; }
        public virtual Category Category { get; set; }
    }
}