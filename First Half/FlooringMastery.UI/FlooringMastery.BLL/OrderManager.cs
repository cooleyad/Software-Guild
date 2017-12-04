using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepo;
        private IProductRepository _productRepo;
        private ITaxRepository _taxRepo;

        public OrderManager(IOrderRepository orderFile, IProductRepository product, ITaxRepository tax)
        {
            _orderRepo = orderFile;
            _taxRepo = tax;
            _productRepo = product;
        }

        public OrderResponse LookupOrder(DateTime order)
        {
            OrderResponse response = new OrderResponse();

            response.Order = _orderRepo.LookupOrders(order);

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
        public FindProductTypeResponse GetProductData (string productType)
        {
            FindProductTypeResponse response = new FindProductTypeResponse();

            response.Product = _productRepo.GetProductData(productType);

            if (response.Product==null)
            {
                response.Success = false;
                response.Message = $"{productType} is not valid.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public LookupOrderResponse AccountByDateAndNumber(DateTime date, int orderNumber)
        {
            LookupOrderResponse response = new LookupOrderResponse();

            response.Order = _orderRepo.LookupOrder(date, orderNumber);

            if (response.Order==null)
            {
                response.Success = false;
                response.Message = $"{date} is not a valid order";
            }
            else
            {
                response.Success=true;
            }
            return response;
        }
        public LookupOrderResponse SaveNewOrder (Order order)
        {
            LookupOrderResponse response = new LookupOrderResponse();

            response.Order = order;
            response.Success = _orderRepo.SaveNewOrder(order);

            return response;
        }
        public LookupOrderResponse SaveExistingOrder (Order order)
        {
            LookupOrderResponse response = new LookupOrderResponse();

            response.Order = order;
            response.Success = _orderRepo.SaveExistingOrder(order);

            return response;
        }
        public DeleteOrderResponse DeleteOrder(Order order)

        {
            DeleteOrderResponse response = new DeleteOrderResponse();

            response.Order = order;

            if(response.Order==null)
            {
                response.Success = false;
                response.Message = $"{order} is not a valid order.";

            }
            else
            {
                response.Success = true;
                response.Success = _orderRepo.DeleteOrder(order);
            }
            return response;
        }
    }
}
