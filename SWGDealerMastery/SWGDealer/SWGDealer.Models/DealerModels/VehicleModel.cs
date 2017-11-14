using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWGDealer.Models.DealerModels
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public int VehicleMakeId { get; set; }

        [ForeignKey("VehicleMakeId")]
        public virtual VehicleMake Make { get; set; }
    }
}
