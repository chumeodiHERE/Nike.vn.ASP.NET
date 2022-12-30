using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nike_vn.Models
{
    public class ProductGender
    {
        [Key]
        public long ProductGenderId { get; set; }
        public string ProductGenderName { get; set; }
    }
}