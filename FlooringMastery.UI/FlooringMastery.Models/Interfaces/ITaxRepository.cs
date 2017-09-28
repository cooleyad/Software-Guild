using FLooringMastery.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface ITaxRepository
    {
        Tax State(string stateInput);

        List<Tax> LoadTax();
    }
}
