using SWGDealer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Data
{
    public class SWGDealerManager
    {
        static ISWGDealerRepo _dealerRepo;

        public SWGDealerManager(ISWGDealerRepo dealerRepo)
        {
            _dealerRepo = dealerRepo;
        }


    }
}
