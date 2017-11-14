using SWGDealer.Data.Interfaces;
using SWGDealer.Data.MockRepos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Data
{
    public static class SWGDealerManagerFactory
    {
        public static SWGDealerManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    //return new MockDealerRepository();
                    throw new NotImplementedException();

                case "PROD":
                    //return new EFDealerRepository();
                    throw new NotImplementedException();

                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
