﻿using Microsoft.AspNet.Identity.EntityFramework;
using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Models.DealerModels
{
    public class UserViewModel
    {
        public AppUser AppUser { get; set; }
        public AppRole Role { get; set; }
        public List<SelectListItem> RoleItems { get; set; }
        public string RoleId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The new password must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; }

        public UserViewModel()
        {
            RoleItems = new List<SelectListItem>();
        }

        public void SetRoleItems(IEnumerable<IdentityRole> roles)
        {
            foreach (var role in roles)
            {
                RoleItems.Add(new SelectListItem()
                {
                    Value = role.Id.ToString(),
                    Text = role.Name
                });
            }
        }
    }
}