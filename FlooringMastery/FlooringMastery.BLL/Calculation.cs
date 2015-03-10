using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

        /// <summary>
        /// Given a datetime, check if an order file already exists, return true if it does
        /// </summary>
        /// <param name="myDateTime"></param>
        /// <returns></returns>
        public static bool DoesOrderFileExist(DateTime myDateTime)
        {
            string myDateFileName = DateToFileName(myDateTime);
            if (File.Exists(myDateFileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Given a datetime value, return a string with the proper file name.
        /// </summary>
        /// <param name="fileDate"></param>
        /// <returns></returns>
        public static string DateToFileName(DateTime fileDate)
        {
            string strDate = String.Format("{0:MMddyyyy}", fileDate);
            string filePath = "Orders_" + strDate + ".txt";
            return filePath;
        }

    }
}
