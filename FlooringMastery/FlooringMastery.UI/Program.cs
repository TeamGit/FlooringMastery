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
            
            //foreach (var s in WorkingMemory.OrderList)
            //{
            //    Console.WriteLine(s.OrderNumber);
            //    Console.WriteLine(s.CustomerName);
            //    Console.WriteLine(s.OrderState.StateAbbreviation);
            //    Console.WriteLine(s.OrderState.TaxRate);
            //    Console.WriteLine(s.OrderProduct.ProductType);
            //    Console.WriteLine(s.Area);
            //    Console.WriteLine(s.OrderProduct.CostPerSquareFoot);
            //    Console.WriteLine(s.OrderProduct.LaborCostPerSquareFoot);
            //    Console.WriteLine(s.TotalMaterialCost);
            //    Console.WriteLine(s.TotalLaborCost);
            //    Console.WriteLine(s.TotalTax);
            //    Console.WriteLine(s.TotalCost);
            //}

            var myVar = Input.GetDate("Please enter a date in the format MM/DD/YYYY: ");
            Console.WriteLine(myVar);
            Console.ReadLine();


        }
    }
}
