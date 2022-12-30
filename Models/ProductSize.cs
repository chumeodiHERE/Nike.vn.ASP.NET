using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nike_vn.Models
{
    public class ProductSize
    {
        [Key]
        public long ProductSizeId { get; set; }
        public string ProductSizeName { get; set; }
        public Nullable<long> ApparelId { get; set; }

        public virtual Apparel Apparel { get; set; }
    }
}