using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLooringMastery.Objects;

namespace FlooringMastery.Data
{
    public class OrderTestRepository : IOrderFileRepository
    {
        //create test account information here for workflows, ect like SGBank


        public OrderFile LookupOrder(string OrderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
