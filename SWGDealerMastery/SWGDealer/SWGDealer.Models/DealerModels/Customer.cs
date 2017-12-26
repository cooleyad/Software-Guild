using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Models.DealerModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
