using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public static class Calculation
    {
        public static List<int> GetAllOrderNumbers(DateTime orderDateTime)
        {
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(orderDateTime);

            var orderNumbers = (from o in allOrders
                where true
                select o.OrderNumber).ToList();

            return orderNumbers;
        }

    }
}
