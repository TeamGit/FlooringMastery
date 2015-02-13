using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public static class Calculations
    {
        public static bool CheckForEmptyList()
        {
          
            if (!WorkingMemory.OrderList.Any())
            {
                return true;
            }
            return false;
        }

    }
}
