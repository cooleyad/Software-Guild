using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data.Repos
{
    public class FileTaxRepo : ITaxRepository
    {
        public const string taxPath = @"\\Mac\Home\Desktop\Sample Data\Taxes.txt";

        Dictionary<string, Tax> _stateDictionary;

        public FileTaxRepo()
        {
            _stateDictionary = LoadTax().ToDictionary(d => d.StateAbbreviation);
        }

        public List<Tax> LoadTax()
        {
            List<Tax> taxList = new List<Tax>();

            using (StreamReader sr = new StreamReader(taxPath))
            {
                sr.ReadLine();
                string line;

                while ((line=sr.ReadLine())!=null)
                {
                    Tax tax = new Tax();

                    string[] columns = line.Split(',');

                    tax.StateAbbreviation = columns[0];
                    tax.StateName = columns[1];
                    tax.TaxRate = decimal.Parse(columns[2]);

                    taxList.Add(tax);
                }
            }
            return taxList;
        }

        public Tax State(string stateInput)
        {
            if(_stateDictionary.ContainsKey(stateInput))
            {
                return _stateDictionary[stateInput];
            }
            else
            {
                return null;
            }
        }
    }
}
