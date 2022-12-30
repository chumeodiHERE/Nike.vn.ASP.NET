using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nike_vn.ViewModel
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage = "Please enter valid email.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "First Name cannot be blank.")]
        public string FristName { get; set; }
        [Required(ErrorMessage = "Last Name cannot be blank.")]
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }
    }
}