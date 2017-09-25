using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace FlooringMastery.BLL
{
    public class OrderFileManager
    {
        private IOrderFileRepository _orderFileRepo;

        public OrderFileManager (IOrderFileRepository orderFile)
        {
            _orderFileRepo = orderFile;
        }

        public OrderResponse LookupOrder(DateTime order)
        {
            OrderResponse response = new OrderResponse();

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{order} is not an order in our system.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }    
}
