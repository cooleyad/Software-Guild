using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SWGDealer.Models
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage ="Please enter a message")]
        public string Message { get; set; }
    }
}