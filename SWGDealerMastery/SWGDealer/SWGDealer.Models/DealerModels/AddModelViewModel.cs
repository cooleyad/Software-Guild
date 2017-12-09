using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SWGDealer.Models.DealerModels
{
    public class AddModelViewModel
    {
        public int VehicleModelId { get; set; }
        [Required]
        public string ModelType { get; set; }
        [Required]
        public int VehicleMakeId { get; set; }
        public AppUser User { get; set; }
        public DateTime Added { get; set; }
        public List<SelectListItem> Makes { get; set; }

        public AddModelViewModel()
        {
            Makes = new List<SelectListItem>();
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
    }
}
