using FlooringMastery.Models.Interfaces;
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
    }    
}
