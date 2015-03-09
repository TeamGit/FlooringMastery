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
        /// <summary>
        /// Given a DateTime value, load all the orders for that date and return a list of the ordernumbers
        /// </summary>
        /// <param name="orderDateTime"></param>
        /// <returns></returns>
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
