using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Incorrect email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Incorrect password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

        public AppRole Role { get; set; }
    }
}