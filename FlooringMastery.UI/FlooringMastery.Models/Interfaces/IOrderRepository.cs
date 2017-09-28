using FLooringMastery.Models;
using FLooringMastery.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LookupOrder(DateTime time);
        Order LookupOrder(DateTime time, int orderNumber);
        bool DeleteOrder(Order order);
        bool SaveExistingOrder(Order order);
        bool SaveNewOrder(Order order);
    }
}
