using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class ProdOrders : IContainOrders
    {
        /// <summary>
        /// This method is under construction
        /// </summary>
        /// <param name="fileDate"></param>
        /// <returns></returns>
        public List<Order> LoadOrders(DateTime fileDate)
        {
            //string filePath = DateToFileName(fileDate);
            //using (StreamReader sr = new StreamReader(filePath))
            //    while (!sr.EndOfStream)
            //    {
            //        string WholeOrder = sr.ReadLine();
            //        if (!string.IsNullOrEmpty(WholeOrder))
            //        {
            //            string[] WholeOrderArray = WholeOrder.Split(',');

            //            if (WholeOrderArray[0] == "OrderNumber")
            //            {
            //                WholeOrder = sr.ReadLine();
            //                if (!string.IsNullOrEmpty(WholeOrder))
            //                {
            //                    WholeOrderArray = WholeOrder.Split(',');
            //                }
            //            }

            //            Order newOrder = new Order();


            //            return ()
            //            ;
            return;
        }

        /// <summary>
                    /// Given a date and a list of orders, create a file named using that date, write a header, and write each order to file.
                    /// </summary>
                    /// <param name="fileDate"></param>
                    /// <param name="orders"></param>
                public
            void SaveOrdersToFile(DateTime fileDate, List<Order> orders)
        {
            string filePath = DateToFileName(fileDate);
            File.Create(filePath).Close();
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
            }

            int orderNumber = 1;

            foreach (var myOrder in orders)
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                        orderNumber,
                        myOrder.CustomerName,
                        myOrder.StateAbbreviation,
                        myOrder.TaxRate,
                        myOrder.ProductType,
                        myOrder.Area,
                        myOrder.CostPerSquareFoot,
                        myOrder.LaborCostPerSquareFoot,
                        myOrder.TotalMaterialCost,
                        myOrder.TotalLaborCost,
                        myOrder.TotalTax,
                        myOrder.TotalCost);
                }
                orderNumber++;
            }
        }

    public static string DateToFileName(DateTime fileDate)
    {
            string strDate = String.Format("{0:MMddyyyy}", fileDate);
            string filePath = "Orders_" + strDate + ".txt";
            return filePath;
    }
    }
}
