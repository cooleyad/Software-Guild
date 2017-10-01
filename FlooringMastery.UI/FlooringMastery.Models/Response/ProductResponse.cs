using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Response
{
    public class ProductResponse : Response
    {
        public Order ProductInformation { get; set; }
        public List<Order> ProductList { get; set; }
        public decimal ProductDecimal { get; set; }
    }
}
