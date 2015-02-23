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
        private List<Order> FakeDB { get; set; }

        /// <summary>
        /// Load three static mock orders, as well as the contents of FakeDB, and return the combined list.
        /// </summary>
        /// <param name="fileDate"></param>
        /// <returns></returns>
        public List<Order> LoadOrders(DateTime fileDate)
        {
            List<Order> orders = new List<Order>();

            Order myOrder = new Order();

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

            myOrder.OrderNumber = 2;
            myOrder.CustomerName = "Saul Goodman";
            myOrder.StateAbbreviation = "MN";
            myOrder.TaxRate = 0.0625m;
            myOrder.ProductType = "Laminate";
            myOrder.Area = 200;
            myOrder.CostPerSquareFoot = 1.75m;
            myOrder.LaborCostPerSquareFoot = 2.10m;
            myOrder.TotalMaterialCost = 350m;
            myOrder.TotalLaborCost = 420m;
            myOrder.TotalTax = 48.13m;
            myOrder.TotalCost = 818.13m;

            orders.Add(myOrder);

            myOrder.OrderNumber = 3;
            myOrder.CustomerName = "Jessie Pinkman";
            myOrder.StateAbbreviation = "WI";
            myOrder.TaxRate = 0.0630m;
            myOrder.ProductType = "Carpet";
            myOrder.Area = 300;
            myOrder.CostPerSquareFoot = 4.00m;
            myOrder.LaborCostPerSquareFoot = 3.10m;
            myOrder.TotalMaterialCost = 250m;
            myOrder.TotalLaborCost = 320m;
            myOrder.TotalTax = 50m;
            myOrder.TotalCost = 1000.13m;

            orders.Add(myOrder);

            if (FakeDB.Any())
            {
                foreach (var order in FakeDB)
                {
                    orders.Add(order);
                }
            }

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
