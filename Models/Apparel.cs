using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nike_vn.Models
{
    public class Apparel
    {
        [Key]
        public long ApparelId { get; set; }
        public string ApparelName { get; set; }
    }
}