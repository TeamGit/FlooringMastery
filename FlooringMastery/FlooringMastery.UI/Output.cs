using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.UI.Screens;

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
        
        public static void DisplayAllOrders(DateTime dateObject)
        {
           var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(dateObject);

            foreach (var order in allOrders)
            {
                Output.DisplayOrder(order);
            }
        }



        public static void PauseForReading()
        {
            Console.WriteLine("\n(press enter to continue)");
            Console.ReadLine();
        }

        public static void Go()
        {
            var Screen = new HomeScreen();
            Screen.Run();
        }

        public static void DatePrompt(string prompt)
        {
            Console.Write(prompt);
            Console.Write(DateTime.Now.ToString("MM/dd/yyyy"));
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }

        public static void Prompt(string prompt)
        {
            Console.WriteLine(prompt);
        }

        public static void PromptPlusCurrentValueStr(string prompt, string currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }

        public static void PromptPlusCurrentValueInt(string prompt, int currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ToString());
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }

        public static void PromptPlusCurrentValueDec(string prompt, decimal currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ToString());
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }


    }
}
