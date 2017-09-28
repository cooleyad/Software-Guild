using FLooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Response
{
    public class OrderResponse : Response
    {
        public List<Order> Order { get; set; }
    }
}
