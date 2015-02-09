using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public static class Output
    {
        /// <summary>
        /// Given an order object, display various values to the console
        /// </summary>
        /// <param name="myOrder"></param>
        public static void DisplaySingleOrder(Order myOrder)
        {
            Console.Clear();
            Console.WriteLine("Order Number: {0}", myOrder.OrderNumber);
            Console.WriteLine("Customer name: {0}",myOrder.CustomerName);
            Console.WriteLine("State name: {0}", myOrder.OrderState.StateName);
            Console.WriteLine("Area: {0} square feet",myOrder.Area);
            Console.WriteLine("Product Type: {0}",myOrder.OrderProduct.ProductType);
            Console.WriteLine("Total cost: {0:C}",myOrder.TotalCost);
            string lineOutputFormat = "{0,-30} {1,10:C}";
            Console.WriteLine(lineOutputFormat,"\tTotal Labor cost: ",myOrder.TotalLaborCost);
            Console.WriteLine(lineOutputFormat,"\tTotal Material cost: ",myOrder.TotalMaterialCost);
            Console.WriteLine(lineOutputFormat,"\tTotal Tax cost: ",myOrder.TotalTax);
            Console.ReadLine();
        }
    }
}
