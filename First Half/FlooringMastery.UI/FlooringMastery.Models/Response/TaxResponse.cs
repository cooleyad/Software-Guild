using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Response
{
    public class TaxResponse
    {
        public Tax TaxData { get; set; }
        public List<Order> TaxList { get; set; }
    }
}
