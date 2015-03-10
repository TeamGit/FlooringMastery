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
        /// <summary>
        /// Given an order object display each value in the console.  Bool ShowOrderNumber is true by default.  Order Number will not be displayed if it is false.
        /// </summary>
        /// <param name="myOrder"></param>
        /// <param name="ShowOrderNumber"></param>
        public static void DisplayOrder(Order myOrder, bool ShowOrderNumber=true)
        {
            Console.WriteLine("");
            if (ShowOrderNumber)
            Console.WriteLine("Order Number: {0}", myOrder.OrderNumber);
            Console.WriteLine("Customer Name: {0}", myOrder.CustomerName);
            Console.WriteLine("State: {0}", myOrder.StateAbbreviation);
            Console.WriteLine("Area: {0}", myOrder.Area);
            Console.WriteLine("Product: {0}", myOrder.ProductType);
            string lineOutputFormat = "{0,-30} {1,10:C}";
            Console.WriteLine(lineOutputFormat, "\tTotal Labor Cost: ", myOrder.TotalLaborCost);
            Console.WriteLine(lineOutputFormat, "\tTotal Material Cost: ", myOrder.TotalMaterialCost);
            Console.WriteLine(lineOutputFormat, "\tTotal Tax: ", myOrder.TotalTax);
        }
        
        /// <summary>
        /// Given a date, display each order for that date in the console.
        /// </summary>
        /// <param name="dateObject"></param>
        public static void DisplayAllOrders(DateTime dateObject)
        {
            
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(dateObject);
            if (allOrders != null)
            {
                foreach (var order in allOrders)
                {
                    Output.DisplayOrder(order);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No orders for that date.");
            }
            
        }

        /// <summary>
        /// Display "press enter to continue" then pause until enter is pressed.
        /// </summary>
        public static void PauseForReading()
        {
            Console.WriteLine("\n(Press enter to continue)");
            Console.ReadLine();
        }

        /// <summary>
        /// Create a homescreen and execute it's run method.
        /// </summary>
        public static void Go()
        {
            var Screen = new HomeScreen();
            Screen.Run();
        }

        /// <summary>
        /// Given a prompt, display that prompt and todays date in the console, set cursor to overwrite date.
        /// </summary>
        /// <param name="prompt"></param>
        public static void DatePrompt(string prompt)
        {
            Console.Write(prompt);
            Console.Write(DateTime.Now.ToString("MM/dd/yyyy"));
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }

        /// <summary>
        /// Given a prompt, display it in the console.
        /// </summary>
        /// <param name="prompt"></param>
        public static void Prompt(string prompt)
        {
            Console.WriteLine(prompt);
        }

        /// <summary>
        /// Given a prompt and a string value, display the prompt and then the value in the console.  Set the cursor to overwrite the value.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        public static void PromptPlusCurrentValueStr(string prompt, string currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }

        /// <summary>
        /// Given a prompt and an int, display the prompt and then the int in the console.  Set the cursor to overwrite the int.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        public static void PromptPlusCurrentValueInt(string prompt, int currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ToString());
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }

        /// <summary>
        /// Given a prompt and a decimal, display the prompt and then the decimal in the consolel.  Set the cursor to overwrite the decimal.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        public static void PromptPlusCurrentValueDec(string prompt, decimal currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ToString());
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
        }


    }
}
