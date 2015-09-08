using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [DisplayName("Your Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [DisplayName("Your Email")]
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        [DisplayName("Your Phone")]
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [DisplayName("Will you attend")]
        [Required(ErrorMessage = "Please specified whether you will attend")]
        public bool? WillAttend { get; set; }
    }
}
