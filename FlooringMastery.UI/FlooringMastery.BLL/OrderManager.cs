using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;


namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepo;
        private IProductRepository _productRepo;
        private ITaxRepository _taxRepo;

        public OrderManager(Data.OrderTestRepository orderTestRepository, IOrderRepository orderFile, 
            Data.ProductTestRepository productTestRepository, IProductRepository product,
            Data.TaxTestRepository taxTestRepository, ITaxRepository tax)
        {
            _orderRepo = orderFile;
            _taxRepo = tax;
            _productRepo = product;
        }

        public OrderResponse LookupOrder(DateTime order)
        {
            OrderResponse response = new OrderResponse();

            response.Order = _orderRepo.LookupOrder(order);

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
        public FindStateResponse GetStateTax(string state)
        {
            FindStateResponse response = new FindStateResponse();

            response.StateTax = _taxRepo.State(state);

            if (response.StateTax == null)
            {
                response.Success = false;
                response.Message = $"{state} is not valid.";

            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
