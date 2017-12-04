using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class TaxTestRepository : ITaxRepository
    {
        private static readonly List<Tax> StateTax = new List<Tax>()
        {
            //OH,Ohio,6.25
            new Tax
            {
                StateAbbreviation="OH",
                StateName="Ohio",
                TaxRate=6.25M

            },
            //PA,Pennsylvania,6.75
            new Tax
            {
                StateAbbreviation="PA",
                StateName="Pennsylvania",
                TaxRate=6.75M
            },
            //MI,Michigan,5.75
            new Tax
            {
                StateAbbreviation="MI",
                StateName="Michigan",
                TaxRate=5.75M

            },
            //IN,Indiana,6.00
            new Tax
            {
                StateAbbreviation="IN",
                StateName="Indiana",
                TaxRate=6.00M

            }

        };

        public Tax State(string stateInput)
        {
            return StateTax.FirstOrDefault(t => t.StateName == stateInput); 
        }

        public List<Tax> LoadTax()
        {
            return StateTax;
        } 
    }
}
