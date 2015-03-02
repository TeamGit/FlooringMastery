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
    public class TestOrders : IContainOrders
    {
        public List<Order> FakeDB { get; set; }

        /// <summary>
        /// Load three static mock orders, as well as the contents of FakeDB, and return the combined list.
        /// </summary>
        /// <param name="fileDate"></param>
        /// <returns></returns>
        public List<Order> LoadOrders(DateTime fileDate)
        {
            List<Order> orders = new List<Order>();

            if (FakeDB != null)
            {
                if (FakeDB.Any())
                {
                    foreach (var order in FakeDB)
                    {
                        orders.Add(order);
                    }
                }
            }
            else
            {
                FakeDB = new List<Order>();
            }
        
            Order myOrder = new Order();
            Order myOrder1 = new Order();
            Order myOrder2 = new Order();


            myOrder.OrderNumber = 1;
            myOrder.CustomerName = "Walter White";
            myOrder.StateAbbreviation = "IA";
            myOrder.TaxRate = 0.0675m;
            myOrder.ProductType = "Wood";
            myOrder.Area = 100;
            myOrder.CostPerSquareFoot = 5.15m;
            myOrder.LaborCostPerSquareFoot = 4.75m;
            myOrder.TotalMaterialCost = 515m;
            myOrder.TotalLaborCost = 475m;
            myOrder.TotalTax = 66.82m;
            myOrder.TotalCost = 1056.82m;

            orders.Add(myOrder);

            myOrder1.OrderNumber = 2;
            myOrder1.CustomerName = "Saul Goodman";
            myOrder1.StateAbbreviation = "MN";
            myOrder1.TaxRate = 0.0625m;
            myOrder1.ProductType = "Laminate";
            myOrder1.Area = 200;
            myOrder1.CostPerSquareFoot = 1.75m;
            myOrder1.LaborCostPerSquareFoot = 2.10m;
            myOrder1.TotalMaterialCost = 350m;
            myOrder1.TotalLaborCost = 420m;
            myOrder1.TotalTax = 48.13m;
            myOrder1.TotalCost = 818.13m;

            orders.Add(myOrder1);

            myOrder2.OrderNumber = 3;
            myOrder2.CustomerName = "Jessie Pinkman";
            myOrder2.StateAbbreviation = "WI";
            myOrder2.TaxRate = 0.0630m;
            myOrder2.ProductType = "Carpet";
            myOrder2.Area = 300;
            myOrder2.CostPerSquareFoot = 4.00m;
            myOrder2.LaborCostPerSquareFoot = 3.10m;
            myOrder2.TotalMaterialCost = 250m;
            myOrder2.TotalLaborCost = 320m;
            myOrder2.TotalTax = 50m;
            myOrder2.TotalCost = 1000.13m;

            orders.Add(myOrder2);



            return orders;

        }

        /// <summary>
        /// Given a list of orders, store them in FakeDB.  Do nothing with the date parameter in this test method.
        /// </summary>
        /// <param name="fileDate"></param>
        /// <param name="orders"></param>
        public void SaveOrdersToFile(DateTime fileDate, List<Order> orders)
        {
            FakeDB.Clear();

            foreach (var order in orders)
            {
              FakeDB.Add(order);  
            }
        }
    }
}
