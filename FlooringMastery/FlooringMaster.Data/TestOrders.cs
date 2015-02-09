using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class TestOrders : IContainOrders
    {
        /// <summary>
        /// Returns a order object
        /// </summary>
        /// <returns></returns>
        public Order GetOrder()
        {
            Order myOrder = new Order();
            
            myOrder.OrderNumber = 1;
            myOrder.CustomerName = "Wise";
            myOrder.OrderState.TaxRate = 6.25M;
            myOrder.OrderState.StateAbbreviation = Enums.StateAbbreviations.AK;
            myOrder.OrderState.StateName = Enums.StateNames.Alaska;
            myOrder.Area = 100.00M;
            myOrder.OrderProduct.ProductType = "Wood";
            myOrder.OrderProduct.CostPerSquareFoot = 5.15M;
            myOrder.OrderProduct.LaborCostPerSquareFoot = 4.75M;
            myOrder.TotalMaterialCost = 515.00M;
            myOrder.TotalLaborCost = 475.00M;
            myOrder.TotalTax = 61.88M;
            myOrder.TotalCost = 1051.88M;

            return myOrder;

        }

        /// <summary>
        /// Read in multiple orders from a text file
        /// </summary>
        public void GetAllOrders()
        {
            using (StreamReader sr = new StreamReader("TestOrders.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeOrder = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeOrder))
                    {

                        string[] WholeOrderArray = WholeOrder.Split(',');

                        Order newOrder = new Order();


                        int orderNumber;
                        if (int.TryParse(WholeOrderArray[0], out orderNumber))
                        {
                            newOrder.OrderNumber = orderNumber;
                        }


                        newOrder.CustomerName = WholeOrderArray[1];


                        Enums.StateAbbreviations stateAbbrevs;
                        if (Enums.StateAbbreviations.TryParse(WholeOrderArray[2], out stateAbbrevs))
                        {
                            newOrder.OrderState.StateAbbreviation = stateAbbrevs;
                        }


                        decimal taxRate;
                        if (decimal.TryParse(WholeOrderArray[3], out taxRate))
                        {
                            newOrder.OrderState.TaxRate = taxRate;
                        }


                        newOrder.OrderProduct.ProductType = WholeOrderArray[4];


                        decimal orderArea;
                        if (decimal.TryParse(WholeOrderArray[5], out orderArea))
                        {
                            newOrder.Area = orderArea;
                        }


                        decimal costPerSquareFoot;
                        if (decimal.TryParse(WholeOrderArray[6], out costPerSquareFoot))
                        {
                            newOrder.OrderProduct.CostPerSquareFoot = costPerSquareFoot;
                        }


                        decimal laborCostPerSquareFoot;
                        if (decimal.TryParse(WholeOrderArray[7], out laborCostPerSquareFoot))
                        {
                            newOrder.OrderProduct.LaborCostPerSquareFoot = laborCostPerSquareFoot;
                        }


                        decimal materialCost;
                        if (decimal.TryParse(WholeOrderArray[8], out materialCost))
                        {
                            newOrder.TotalMaterialCost = materialCost;
                        }


                        decimal laborCost;
                        if (decimal.TryParse(WholeOrderArray[9], out laborCost))
                        {
                            newOrder.TotalLaborCost = laborCost;
                        }


                        decimal totalTax;
                        if (decimal.TryParse(WholeOrderArray[10], out totalTax))
                        {
                            newOrder.TotalTax = totalTax;
                        }


                        decimal totalCost;
                        if (decimal.TryParse(WholeOrderArray[11], out totalCost))
                        {
                            newOrder.TotalCost = totalCost;
                        }

                        WorkingMemory.OrderList.Add(newOrder);
                    }

                }
                  
        }

    }
}
