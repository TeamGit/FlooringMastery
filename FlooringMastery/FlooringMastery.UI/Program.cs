using System;
using System.Collections.Generic;
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
            //TestStates myTester = new TestStates();
            //myTester.GetStates();

            //foreach (var s in WorkingMemory.StateList)
            //{
            //    Console.WriteLine(s.StateAbbreviation);
            //    Console.WriteLine(s.StateName);
            //    Console.WriteLine(s.TaxRate);
            //    Console.WriteLine();
            //}
            //Console.ReadLine();

            TestProducts myProductTester = new TestProducts();
            myProductTester.GetProducts();

            foreach (var s in WorkingMemory.ProductList)
            {
                Console.WriteLine(s.ProductType);
                Console.WriteLine(s.CostPerSquareFoot);
                Console.WriteLine(s.LaborCostPerSquareFoot);
            }
            Console.ReadLine();
        }
    }
}
