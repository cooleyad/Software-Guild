using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Models.DealerModels
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Vin { get; set; }
        public virtual VehicleModel Model { get; set; }
        //public int ModelId { get; set; }
        public int Year { get; set; }
        public string BodyStyle { get; set; }
        public string TransmissionType { get; set; }
        public string Color { get; set; }
        public string InteriorColor { get; set; }
        public int Odometer { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool VehicleIsNew { get; set; }
        public bool VehicleIsSold { get; set; }
        public bool VehicleFeatured { get; set; }
    }
}
