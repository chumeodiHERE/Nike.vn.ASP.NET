using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nike_vn.Models
{
    public class Store
    {
        [Key, Column(Order = 1)]
        public long ProductId { get; set; }

        [Key, Column(Order = 2)]
        public long ProductSizeId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductSize ProductSize { get; set; }
    }
}