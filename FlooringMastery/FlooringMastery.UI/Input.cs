using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public class Input
    {
        /// <summary>
        /// Given a prompt, continually prompt the user until a Date is input.  Return that date as a DateTime
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static DateTime GetDate(string prompt)
        {
            DateTime dateValue;
            do
            {
                Output.DatePrompt(prompt);

                string dateInput = Console.ReadLine();
                if (String.IsNullOrEmpty(dateInput))
                    dateInput = DateTime.Now.ToString("MM/dd/yyyy");
                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    return dateValue;
                }
                Console.WriteLine("Please enter the date in the format MM/DD/YYYY.");
            } while (true);
        }

        /// <summary>
        /// Given a prompt, continually prompt the user until they input a non empty string.  Return that string.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetNonEmptyString(string prompt)
        {
            string input;

            do
            {
                Output.Prompt(prompt);
                input = Console.ReadLine();
            } while (String.IsNullOrEmpty(input));

            return input.Trim();
        }

        /// <summary>
        /// Given a prompt, continually prompt the user until they put in an int, return that int.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int GetInt(string prompt)
        {
            int myInt;
            do
            {
                Output.Prompt(prompt);
                string stringInput = Console.ReadLine();
                if (String.IsNullOrEmpty(stringInput))
                {
                    continue;
                }

                if (int.TryParse(stringInput, out myInt))
                {
                    return myInt;
                }
            } while (true);
        }

        /// <summary>
        /// Given a prompt, continually prompt the user until they put in a decimal, return that decimal.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string prompt)
        {
            decimal myDecimal;

            do
            {
                Output.Prompt(prompt);
                string stringInput = Console.ReadLine();
                if (String.IsNullOrEmpty(stringInput))
                {
                    continue;
                }

                if (decimal.TryParse(stringInput, out myDecimal))
                {
                    return myDecimal;
                }
            } while (true);
        }

        /// <summary>
        /// Given a current value, return that value or a different string input in the console.
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static string GetStringEdit(string currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue;
            }
            return input.Trim();
        }

        
        /// <summary>
        /// Given an int value, return that value or one input in the console.
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static int GetIntEdit(int currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue.ToString();
            }
            int outputInt;
            if (int.TryParse(input, out outputInt))
            {
                return outputInt;
            }
            return currentValue;
        }

        /// <summary>
        /// Given a decimal value, return that value or a new one edited in the console.
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static decimal GetDecimalEdit(decimal currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue.ToString();
            }
            decimal outputDecimal;
            if (decimal.TryParse(input, out outputDecimal))
            {
                return outputDecimal;
            }
            return currentValue;
        }

        /// <summary>
        /// Prompt the user for each value of an Order object, return that object.
        /// </summary>
        /// <returns></returns>
        public static Order GetOrder()
        {
            Order myOrder = new Order();

            myOrder.CustomerName = GetNonEmptyString("Please enter the customer's name.");
            myOrder.StateAbbreviation = GetNonEmptyString("Please enter the State Abbreviation");
            myOrder.Area = GetDecimal("Please enter the are of the floor in feet squared.");
            myOrder.ProductType = GetNonEmptyString("Please enter the product type.");
            //myOrder.TotalLaborCost = GetDecimal("Please enter the total labor cost.");
            //myOrder.TotalMaterialCost = GetDecimal("Please enter the total material cost.");
            //myOrder.TotalTax = GetDecimal("Please enter the total tax.");

            return myOrder;
        }
    }
}
