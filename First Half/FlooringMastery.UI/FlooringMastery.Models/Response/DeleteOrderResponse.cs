using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Response
{
    public class DeleteOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}
