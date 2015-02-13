//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FlooringMastery.Models;

//namespace FlooringMaster.Data
//{
//    public class TestOrders : IContainOrders
//    {
        
//        /// <summary>
//        /// Read in multiple orders from a text file
//        /// </summary>
//        private static void LoadOrders()
//        {
//            WorkingMemory.OrderList.Clear();
//            using (StreamReader sr = new StreamReader(WorkingMemory.CurrentOrderFile))
//                while (!sr.EndOfStream)
//                {
//                    string WholeOrder = sr.ReadLine();
//                    if (!string.IsNullOrEmpty(WholeOrder))
//                    {

//                        string[] WholeOrderArray = WholeOrder.Split(',');

//                        if (WholeOrderArray[0] == "OrderNumber")
//                        {
//                            WholeOrder = sr.ReadLine();
//                            if (!string.IsNullOrEmpty(WholeOrder))
//                            {
//                                WholeOrderArray = WholeOrder.Split(',');
//                            }
                            
//                        }

//                        Order newOrder = new Order();


//                        int orderNumber;
//                        if (int.TryParse(WholeOrderArray[0], out orderNumber))
//                        {
//                            newOrder.OrderNumber = orderNumber;
//                        }


//                        newOrder.CustomerName = WholeOrderArray[1];


//                        Enums.StateAbbreviations stateAbbrevs;
//                        if (Enums.StateAbbreviations.TryParse(WholeOrderArray[2], out stateAbbrevs))
//                        {
//                            var temp = from s in WorkingMemory.StateList
//                                       where s.StateAbbreviation.ToString().Equals(stateAbbrevs.ToString(), StringComparison.OrdinalIgnoreCase)
//                                       select s;
                            
//                            foreach (var s in temp)
//                            {
//                                newOrder.OrderState = s;
//                            }
//                        }


//                        decimal taxRate;
//                        if (decimal.TryParse(WholeOrderArray[3], out taxRate))
//                        {
//                            newOrder.OrderState.TaxRate = taxRate;
//                        }


//                       var temp2 = from p in WorkingMemory.ProductList
//                                   where p.ProductType.Equals(WholeOrderArray[4], StringComparison.OrdinalIgnoreCase)
//                                   select p;

//                        foreach (var p in temp2)
//                        {
//                            newOrder.OrderProduct = p;
//                        }


//                        decimal orderArea;
//                        if (decimal.TryParse(WholeOrderArray[5], out orderArea))
//                        {
//                            newOrder.Area = orderArea;
//                        }


//                        decimal costPerSquareFoot;

//                        if (decimal.TryParse(WholeOrderArray[6], out costPerSquareFoot))
//                        {
//                            newOrder.OrderProduct.CostPerSquareFoot = costPerSquareFoot;
//                        }


//                        decimal laborCostPerSquareFoot;

//                        if (decimal.TryParse(WholeOrderArray[7], out laborCostPerSquareFoot))
//                        {
//                            newOrder.OrderProduct.LaborCostPerSquareFoot = laborCostPerSquareFoot;
//                        }


//                        decimal materialCost;
//                        if (decimal.TryParse(WholeOrderArray[8], out materialCost))
//                        {
//                            newOrder.TotalMaterialCost = materialCost;
//                        }


//                        decimal laborCost;
//                        if (decimal.TryParse(WholeOrderArray[9], out laborCost))
//                        {
//                            newOrder.TotalLaborCost = laborCost;
//                        }


//                        decimal totalTax;
//                        if (decimal.TryParse(WholeOrderArray[10], out totalTax))
//                        {
//                            newOrder.TotalTax = totalTax;
//                        }


//                        decimal totalCost;
//                        if (decimal.TryParse(WholeOrderArray[11], out totalCost))
//                        {
//                            newOrder.TotalCost = totalCost;
//                        }

                        
//                        WorkingMemory.OrderList.Add(newOrder);
//                    }

//                }

//        }

//        /// <summary>
//        /// Given a date in a specific format, open an order file for that date.  If the file does not exist, create it.
//        /// </summary>
//        /// <param name="date"></param>
//        /// <returns></returns>
//        public string LoadOrderFile(string date)
//        {

//            string properFileName = FileNameBuilder(date);
//            WorkingMemory.CurrentOrderFile = properFileName;
//            if (System.IO.File.Exists(properFileName))
//            {
//                LoadOrders();
//                return "File was loaded successfully.";
//            }
//            System.IO.File.Create(properFileName).Close();
//            return "A new order file was created for that date.";
//        }

//        /// <summary>
//        /// Write the current working memory list of orders to file.
//        /// </summary>
//        public void SaveOrdersToFile()
//        {

//            int orderNumber = 1;
//            File.Create(WorkingMemory.CurrentOrderFile).Close();

//            using (StreamWriter sw = new StreamWriter(WorkingMemory.CurrentOrderFile, true))
//            {
//                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
//            }

//            foreach (var myOrder in WorkingMemory.OrderList)
//            {
//                using (StreamWriter sw = new StreamWriter(WorkingMemory.CurrentOrderFile, true))
//                {
//                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
//                        orderNumber,
//                        myOrder.CustomerName,
//                        myOrder.OrderState.StateAbbreviation,
//                        myOrder.OrderState.TaxRate,
//                        myOrder.OrderProduct.ProductType,
//                        myOrder.Area,
//                        myOrder.OrderProduct.CostPerSquareFoot,
//                        myOrder.OrderProduct.LaborCostPerSquareFoot,
//                        myOrder.TotalMaterialCost,
//                        myOrder.TotalLaborCost,
//                        myOrder.TotalTax,
//                        myOrder.TotalCost);
//                }
//                orderNumber++;
//            }
//        }


//        /// <summary>
//        /// given a string, build a valid path and prefix the filename with Orders_ and append .txt
//        /// </summary>
//        /// <param name="input"></param>
//        /// <returns></returns>
//        public static string FileNameBuilder(string input)
//        {
//            string filename = input;
//            if (!filename.EndsWith(".txt", true, CultureInfo.CurrentCulture))
//            {
//                filename = input + ".txt";
//            }
//            if (!filename.StartsWith(@"..\..\..\Documents\Orders_"))
//            {
//                filename = @"..\..\..\Documents\Orders_" + filename;
//            }
//            else
//            {
//                filename = input;
//            }
//            return filename;
//        }

//    }
//}
