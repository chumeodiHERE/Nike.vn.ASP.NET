using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nike_vn.Models
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public string UserId { get; set; }
        public long Total { get; set; }
    }
}