using FlooringMastery.Data;
using FlooringMastery.Data.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();



            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository(), 
                        new ProductTestRepository(), 
                        new TaxTestRepository());

                case "Live":
                    return new OrderManager(new FileOrderRepo(), 
                        new FileProductRepo(), 
                        new FileTaxRepo());


                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
