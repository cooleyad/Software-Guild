using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Models.DealerModels
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage ="A first name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage ="An email is required")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage ="A message is required")]
        public string Message { get; set; }

    }
}
