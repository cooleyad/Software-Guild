using FlooringMastery.Data;
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
        public static OrderFileManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    throw new Exception("Mode value in app config is not valid");

                case "Product":
                    throw new NotImplementedException();

                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
