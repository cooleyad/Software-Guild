using FLooringMastery.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class OrderLookupResponse : Responses
    {
        public List<OrderFile> Orders { get; set; }
    }
}
