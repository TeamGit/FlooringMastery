using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public static class Input
    {
        /// <summary>
        /// Given a prompt, continually prompt the user until they enter a non-empty string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetString(string prompt)
        {
            string input = null;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

            } while (string.IsNullOrEmpty(input));
            
            return input;
        }

        /// <summary>
        /// take a string parse it into a date time, format it, and return it as a new string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetDate(string prompt)
        {
            DateTime dateValue;
            int linecounter = 1;
            do
            {
                Console.Write(prompt);
                Console.Write(DateTime.Now.ToString("MM/dd/yyyy"));
                Console.SetCursorPosition(prompt.Length,linecounter);
                
                string dateInput = Console.ReadLine();
                if (String.IsNullOrEmpty(dateInput))
                    dateInput = DateTime.Now.ToString("MM/dd/yyyy");

                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    string newString = dateValue.ToString("MMddyyyy");
                    return newString;
                }
                linecounter++;
            } while (true);

        }

        public static decimal GetDecimal(string prompt)
        {
            string input = null;
            decimal myDecimal = 0;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                if (decimal.TryParse(input, out myDecimal))
                {
                    //If decimal is positive loop will break
                }

            } while (myDecimal < 0);

            return myDecimal;
        }

        /// <summary>
        /// Query user for a new order, return that order.
        /// </summary>
        /// <returns></returns>
        public static Order QueryUserForOrder()
        {
            Order myOrder = new Order();

            StateDictionaryClass aDictionary = new StateDictionaryClass();

            myOrder.CustomerName = GetString("Please enter the customer name");

            myOrder.OrderState = GetState();

            myOrder.OrderProduct = GetProduct();

            myOrder.Area = GetDecimal("Please enter the area of the floor");

            myOrder.TotalLaborCost = myOrder.Area * myOrder.OrderProduct.LaborCostPerSquareFoot;

            myOrder.TotalMaterialCost = myOrder.Area * myOrder.OrderProduct.CostPerSquareFoot;

            decimal subTotal = myOrder.TotalLaborCost + myOrder.TotalMaterialCost;

            myOrder.TotalTax = subTotal*myOrder.OrderState.TaxRate;

            myOrder.TotalCost = subTotal + myOrder.TotalTax;

            return myOrder;
        }

        /// <summary>
        /// Query user for a state that exists on the state list, return that state
        /// </summary>
        /// <returns></returns>
        private static State GetState()
        {
            bool gotState = false;
            //Enums.StateAbbreviations stateAbbrevs;
            string tempState;

            do
            {
                tempState = GetString("Please enter the state abbreviation");

                if (WorkingMemory.StateList.Any(s => s.StateAbbreviation.ToString().Equals(tempState, StringComparison.OrdinalIgnoreCase)))
                {
                    gotState = true;
                }
            } while (!gotState);
            
            var temp = from s in WorkingMemory.StateList
                       where s.StateAbbreviation.ToString().Equals(tempState, StringComparison.OrdinalIgnoreCase) 
                       select s;

            State myState = new State();
            
            foreach (var s in temp)
            {
                myState = s;
            }
            return myState;
        }

        /// <summary>
        /// Query user for a product that exists on the product list, return that product
        /// </summary>
        /// <returns></returns>
        private static Product GetProduct()
        {
            bool gotProduct = false;
            List<string> myProducts = new List<string>();

            foreach (var s in WorkingMemory.ProductList)
            {
                myProducts.Add(s.ProductType);
            }
            string tempProduct;        

            do
            {
                tempProduct = GetString("Please enter the product name");
                
                if (myProducts.Any(s => s.Equals(tempProduct, StringComparison.OrdinalIgnoreCase)))
                {
                    gotProduct = true;
                }
            } while (!gotProduct);

            Product newProduct = new Product();

            var temp = from p in WorkingMemory.ProductList
                       where p.ProductType.Equals(tempProduct, StringComparison.OrdinalIgnoreCase) 
                select p;

            foreach (var p in temp)
            {
                newProduct = p;
            }
            return newProduct;
        }

        /// <summary>
        /// Ask the user if they want to commit changes, return a bool indicating their choice.
        /// </summary>
        /// <returns></returns>
        public static bool QueryForCommit()
        {
            bool badAnswer = true;

            do
            {
                Console.WriteLine("Would you like to commit changes to file? Y/N");
                string commitAnswer = Console.ReadLine();
                if (commitAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase) ||
                    commitAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                else if (commitAnswer.Equals("n", StringComparison.CurrentCultureIgnoreCase) ||
                    commitAnswer.Equals("no", StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }
            } while (badAnswer);
            return false;
        }

 
    }
}
