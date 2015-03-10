using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class ProdOrders : IContainOrders
    {
        /// <summary>
        /// Given a date object, return a list of orders from the file for that date.  If there is no file for that date, return null.
        /// </summary>
        /// <param name="fileDate"></param>
        /// <returns></returns>
        public List<Order> LoadOrders(DateTime fileDate)
        {
            List<Order> listOrders = new List<Order>();
            string filePath = DateToFileName(fileDate);

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                    while (!sr.EndOfStream)
                    {
                        string WholeOrder = sr.ReadLine();
                        if (!string.IsNullOrEmpty(WholeOrder))
                        {
                            string[] WholeOrderArray = WholeOrder.Split(',');

                            if (WholeOrderArray[0] == "OrderNumber")
                            {
                                WholeOrder = sr.ReadLine();
                                if (!string.IsNullOrEmpty(WholeOrder))
                                {
                                    WholeOrderArray = WholeOrder.Split(',');
                                }
                                else
                                {
                                    return listOrders;
                                }
                            }

                            Order newOrder = new Order();

                            newOrder.OrderNumber = int.Parse(WholeOrderArray[0]);
                            newOrder.CustomerName = WholeOrderArray[1];
                            newOrder.StateAbbreviation = WholeOrderArray[2];
                            newOrder.TaxRate = decimal.Parse(WholeOrderArray[3]);
                            newOrder.ProductType = WholeOrderArray[4];
                            newOrder.Area = decimal.Parse(WholeOrderArray[5]);
                            newOrder.CostPerSquareFoot = decimal.Parse(WholeOrderArray[6]);
                            newOrder.LaborCostPerSquareFoot = decimal.Parse(WholeOrderArray[7]);
                            newOrder.TotalMaterialCost = decimal.Parse(WholeOrderArray[8]);
                            newOrder.TotalLaborCost = decimal.Parse(WholeOrderArray[9]);
                            newOrder.TotalTax = decimal.Parse(WholeOrderArray[10]);
                            newOrder.TotalCost = decimal.Parse(WholeOrderArray[11]);

                            listOrders.Add(newOrder);
                        }
                    }

                return listOrders;
            }
            else
                return null;

        }

        /// <summary>
        /// Given a date and a list of orders, create a file named using that date, write a header, and write each order to file.
        /// </summary>
        /// <param name="fileDate"></param>
        /// <param name="orders"></param>
        public void SaveOrdersToFile(DateTime fileDate, List<Order> orders)
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
