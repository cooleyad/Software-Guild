using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Models.DealerModels
{
    public class VehicleMake
    {
        public int VehicleMakeId { get; set; }
        public string VehicleMakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public AppUser User { get; set; }
        public string UserName { get; set; }
        //public virtual List <VehicleModel> ModelList { get; set; }
    }
}
