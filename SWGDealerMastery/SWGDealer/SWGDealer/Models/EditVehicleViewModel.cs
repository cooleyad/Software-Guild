using SWGDealer.Models.DealerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Models
{
    public class EditVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Vehicle Make is required ")]
        public int? VehicleMakeId { get; set; }
        [Required(ErrorMessage = "Vehicle Model is required")]
        public int VehicleModelId { get; set; }
        public virtual VehicleModel GetModel { get; set; }
        [Range(2000, 2018)]
        public int Year { get; set; }
        [Required(ErrorMessage = "VIN is required")]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Body Style is required")]
        public string BodyStyle { get; set; }
        [Required(ErrorMessage = "Transmission type is required")]
        public string TransmissionType { get; set; }
        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Interior Color is required")]
        public string InteriorColor { get; set; }
        [Required(ErrorMessage = "Odometer is required")]
        public int Odometer { get; set; }
        [Required(ErrorMessage = "Sale Price is required")]
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int PurchaseTypeId { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> Makes { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> PurchaseTypes { get; set; }

        [Required]
        public bool IsNew { get; set; }
        [Required]
        public bool IsSold { get; set; }
        [Required]
        public bool Featured { get; set; }


        public EditVehicleViewModel()
        {
            Makes = new List<SelectListItem>();
            Models = new List<SelectListItem>();
            PurchaseTypes = new List<SelectListItem>();
        }

        public void SetMakes(IEnumerable<VehicleMake> vehicleMake)
        {
            foreach (var make in vehicleMake)
            {
                Makes.Add(new SelectListItem()
                {
                    Value = make.VehicleMakeId.ToString(),
                    Text = make.VehicleMakeName
                });

            }
        }
        public void SetModels(IEnumerable<VehicleModel> vehicleModel)
        {
            foreach (var model in vehicleModel)
            {
                Models.Add(new SelectListItem()
                {
                    Value = model.VehicleModelId.ToString(),
                    Text = model.VehicleModelName
                });
            }
        }
    }
}