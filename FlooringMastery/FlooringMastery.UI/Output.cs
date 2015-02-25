using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public static class Output
    {
        public static void DisplayOrder(Order myOrder)
        {
            Console.WriteLine("");
            Console.WriteLine("Order Number: {0}", myOrder.OrderNumber);
            Console.WriteLine("Customer Name: {0}", myOrder.CustomerName);
            Console.WriteLine("State: {0}", myOrder.StateAbbreviation);
            Console.WriteLine("Area: {0}", myOrder.Area);
            Console.WriteLine("Product: {0}", myOrder.ProductType);
            string lineOutputFormat = "{0,-30} {1,10:C}";
            Console.WriteLine(lineOutputFormat, "\tTotal Labor cost: ", myOrder.TotalLaborCost);
            Console.WriteLine(lineOutputFormat, "\tTotal Material cost: ", myOrder.TotalMaterialCost);
            Console.WriteLine(lineOutputFormat, "\tTotal Tax cost: ", myOrder.TotalTax);

        }
    }
}
