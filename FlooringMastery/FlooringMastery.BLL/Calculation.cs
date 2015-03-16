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
        /// Given an order object, calculate most fields based on area, state abbreviation, and product type. Return the order object with all fields populated.
        /// </summary>
        /// <param name="myOrder"></param>
        /// <returns></returns>
        public static Order CalculateRemainingProperties(Order myOrder)
        {
            List<State> myStates = SetTestOrProd.MyStatesObject.GetStates();
            List<Product> myProducts = SetTestOrProd.MyProductObject.GetProducts();

            State currentState = myStates.FirstOrDefault(s => s.StateAbbreviation.ToUpper() == myOrder.StateAbbreviation.ToUpper());
            Product currentProduct = myProducts.FirstOrDefault(p => p.ProductType.ToUpper() == myOrder.ProductType.ToUpper());

            myOrder.TaxRate = currentState.TaxRate;
            myOrder.CostPerSquareFoot = currentProduct.CostPerSquareFoot;
            myOrder.LaborCostPerSquareFoot = currentProduct.LaborCostPerSquareFoot;
            myOrder.TotalLaborCost = myOrder.Area*myOrder.LaborCostPerSquareFoot;
            myOrder.TotalMaterialCost = myOrder.Area*myOrder.CostPerSquareFoot;
            decimal subtotal = myOrder.TotalLaborCost + myOrder.TotalMaterialCost;
            myOrder.TotalTax = subtotal*(myOrder.TaxRate/100);
            myOrder.TotalCost = myOrder.TotalTax + subtotal;

            return myOrder;
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
