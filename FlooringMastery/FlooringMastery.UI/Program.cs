using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.Models;
using FlooringMastery.UI.Screens;
using FlooringMastery.BLL;

namespace FlooringMastery.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStates myState = new TestStates();

            //var date = Input.GetDate("Please enter a date.");
            TestProducts myThingy = new TestProducts();

            TestOrders myTestOrders = new TestOrders();

            //Console.WriteLine(myThingy.LoadOrdersFromFile(date));
            
            myState.GetStates();
            myThingy.GetProducts();

            var date = Input.GetDate("Please enter a date: ");
            Console.WriteLine(myTestOrders.LoadOrdersFromFile(date));

            Order s = Input.QueryUserForOrder();

            myTestOrders.SaveOrdersToFile(s);



            //{
            //    Console.WriteLine("Order Number {0}", s.OrderNumber);
            //    Console.WriteLine("Customer name {0}", s.CustomerName);
            //    Console.WriteLine("State Abbreviation {0}", s.OrderState.StateAbbreviation);
            //    Console.WriteLine("Order State {0}", s.OrderState.TaxRate);
            //    Console.WriteLine("Product type {0}", s.OrderProduct.ProductType);
            //    Console.WriteLine("Area {0}", s.Area);
            //    Console.WriteLine("Cost per square foot {0:C}", s.OrderProduct.CostPerSquareFoot);
            //    Console.WriteLine("Labor per square foot {0:C}", s.OrderProduct.LaborCostPerSquareFoot);
            //    Console.WriteLine("Total material cost {0:C}", s.TotalMaterialCost);
            //    Console.WriteLine("Total labor cost {0:C}", s.TotalLaborCost);
            //    Console.WriteLine("Total tax {0:C}", s.TotalTax);
            //    Console.WriteLine("Total cost {0:C}", s.TotalCost);
            //}

            //Console.ReadLine();



        }
    }
}
