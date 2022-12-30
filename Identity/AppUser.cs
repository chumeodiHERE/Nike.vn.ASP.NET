using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nike_vn.Identity
{
    public class AppUser : IdentityUser
    {
        public DateTime? BirthDay { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}