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
        /// <summary>
        /// Returns a bool indidcating if the order listin working memory is empty
        /// </summary>
        /// <returns></returns>
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
