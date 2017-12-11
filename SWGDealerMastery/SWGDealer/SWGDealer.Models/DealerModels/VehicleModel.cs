using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SWGDealer.Models.Identity;

namespace SWGDealer.Models.DealerModels
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
       public int? VehicleMakeId { get; set; }
        public virtual VehicleMake Make { get; set; }
        public AppUser User { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
