using FLooringMastery.Models;
using FLooringMastery.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderFileRepository
    {
        List<OrderFile> LookupOrder(DateTime time);
        OrderFile LookupOrder(string OrderNumber);
        bool DeleteOrder(OrderFile order);
        bool SaveExistingOrder(OrderFile order);
        bool SaveNewOrder(OrderFile order);
    }
}
