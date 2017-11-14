using DVDLibrary.Data.EF;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Data.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public static class DvdRepoFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "MockRepo":
                    return new DvdMockRepository();

                case "AdoRepo":
                    return new DvdRepositoryADO();

                case "EfRepo":
                    return new DvdRepositoryEF();

                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
