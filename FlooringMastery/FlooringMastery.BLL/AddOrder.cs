using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public static class AddOrder
    {
        public static void AddOrderToList(Order myOrder)
        {
            WorkingMemory.OrderList.Add(myOrder);
        }
    }
}
