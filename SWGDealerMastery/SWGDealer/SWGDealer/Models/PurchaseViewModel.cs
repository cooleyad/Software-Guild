using SWGDealer.Models.DealerModels;
using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Models
{
    public class PurchaseViewModel
    {
        public int VehicleId { get; set; }
        [Required(ErrorMessage ="Name is required", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is required", AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Address is required", AllowEmptyStrings = false)]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage ="Phone is required", AllowEmptyStrings = false)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="City is required", AllowEmptyStrings = false)]
        public string City { get; set; }
        [Required(ErrorMessage ="State is required", AllowEmptyStrings = false)]
        public string State { get; set; }
        [Required(ErrorMessage ="ZIP code is required", AllowEmptyStrings = false)]
        public int Zip { get; set; }
        [Required(ErrorMessage ="Sale price is required", AllowEmptyStrings = false)]
        public int SalePrice { get; set; }
        [Required(ErrorMessage = "Purchase type is required", AllowEmptyStrings = false)]
        public PurchaseType PurchaseType { get; set; }
        public AppUser User { get; set; }

        public List<SelectListItem> PurchaseTypes { get; set; }

        public PurchaseViewModel()
        {
            PurchaseTypes = new List<SelectListItem>();
        }

        public void SetPurchaseTypes(IEnumerable<PurchaseType> purchaseType)
        {
            foreach (var type in purchaseType)
            {
                PurchaseTypes.Add(new SelectListItem()
                {
                    Value = type.PurchaseTypeId.ToString(),
                    Text = type.Description
                });
            }
        }
    }
}