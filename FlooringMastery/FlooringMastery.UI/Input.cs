using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    /// <summary>
    /// Input class for taking input from easier
    /// </summary>
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
                Log("non-empty string", "empty string");
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
            do
            {
                Console.Write(prompt);
                Console.Write(DateTime.Now.ToString("MM/dd/yyyy"));
                Console.SetCursorPosition(prompt.Length,Console.CursorTop
                    );
                
                string dateInput = Console.ReadLine();
                if (String.IsNullOrEmpty(dateInput))
                    dateInput = DateTime.Now.ToString("MM/dd/yyyy");

                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    string newString = dateValue.ToString("MMddyyyy");
                    return newString;
                }
                Console.WriteLine("Please enter the date in the format MM/DD/YYYY.");
                Log("date", dateInput);
            } while (true);

        }

        /// <summary>
        /// Given a prompt, continually prompt the user until they enter a non negative decimal then return it
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string prompt)
        {
            string input = null;
            decimal myDecimal = 0;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                foreach (var c in input)
                {
                    var temp = (int)c;
                    //if ((temp < 48) || (temp > 57))
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("Enter the area using digits");
                        Log("integer", input);
                        input = "-100";
                        break;
                    }
                }

                if (decimal.TryParse(input, out myDecimal))
                {
                    //If decimal is positive loop will break
                }

                Log("decimal", input);
                Console.WriteLine("The largest job we can accommodate is {0:N} feet squared.",Decimal.MaxValue);
            } while (myDecimal <= 0);

            return myDecimal;
        }

        /// <summary>
        /// Given a prompt, continually prompt the user until they enter a non negative int, then return it
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int GetInteger(string prompt)
        {
            string input = null;
            int myInteger = 0;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                foreach (var c in input)
                {
                    var temp = (int) c;
                    //if ((temp < 48) || (temp > 57))
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("Enter the area using digits.");
                        Log("integer", input);
                        input = "-100";
                        break;
                    }
                }

                if (int.TryParse(input, out myInteger))
                {
                    //If decimal is positive loop will break
                }

            } while (myInteger < 0);

            return myInteger;
        }


        /// <summary>
        /// Given a prompt, continually prompt the user until they enter a non-null,
        /// non negative int, then return it
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int GetOrderNumber(string prompt)
        {
            string input;
            int myOrderNumber = 0;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                foreach (var c in input)
                {
                    var temp = (int) c;
                    //if ((temp < 48) || (temp > 57))
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("Enter an available order number only.");
                        if (string.IsNullOrEmpty(input))
                        {
                            Log("integer", "null or empty");
                        }
                        else
                        {
                            Log("integer", input);
                        }
                        input = "-100";
                        break;
                }
                }

                if (int.TryParse(input, out myOrderNumber))
                {
                    //If decimal is positive loop will break
                }

            } while ((myOrderNumber < 1) || (myOrderNumber > WorkingMemory.OrderList.Count) || (string.IsNullOrEmpty(input)));

            return myOrderNumber;
        }


        /// <summary>
        /// Query user for a new order, return that order.
        /// </summary>
        /// <returns></returns>
        public static Order QueryUserForOrder()
        {
            Order myOrder = new Order();
                      
            myOrder.CustomerName = (GetString("Enter the customer name: ")).ToUpper();

            State tempState = GetState();

            myOrder.StateAbbreviation = tempState.StateAbbreviation.ToString();
            myOrder.TaxRate = tempState.TaxRate;

            Product tempProduct = GetProduct();
            myOrder.ProductType = tempProduct.ProductType.ToString();
            myOrder.CostPerSquareFoot = tempProduct.CostPerSquareFoot;
            myOrder.LaborCostPerSquareFoot = tempProduct.LaborCostPerSquareFoot;

            myOrder.Area = GetDecimal("Enter the area of the floor in feet squared: ");
            
            myOrder = ChangeOrder.CalculateRemainingProperties(myOrder);

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
                tempState = GetString("Enter the state abbreviation: ");

                if (WorkingMemory.StateList.Any(s => s.StateAbbreviation.ToString().Equals(tempState, StringComparison.OrdinalIgnoreCase)))
                {
                    gotState = true;
                }
                else
                {
                    Console.WriteLine("That isn't recognized as a state in which SWC currently operates.  \nPlease try again.");
                    Console.WriteLine("SWC currently operates in the following states: ");
                    foreach (var state in WorkingMemory.StateList)
                    {
                        Console.Write("{0}    ",state.StateAbbreviation);
                    }
                    Console.WriteLine();
                }

                
                Log("state abbreviation", tempState);

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
                tempProduct = GetString("Enter the product name: ");
                
                if (myProducts.Any(s => s.Equals(tempProduct, StringComparison.OrdinalIgnoreCase)))
                {
                    gotProduct = true;
                }
                else
                {
                    Console.WriteLine("That is not a product currently carried by SWC.\nCurrent products in stock are: ");
                    foreach (var product in WorkingMemory.ProductList)
                    {
                        Console.Write("{0}    ", product.ProductType);
                    }
                    Console.WriteLine("");
                    Log("product name", tempProduct);
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

                Log("yes or no", commitAnswer);

            } while (badAnswer);
            return false;
        }
        
        /// <summary>
        /// Given the expected value and the received value, log invalid input to file
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="received"></param>
        private static void Log(string expected, string received)
        {
            using (System.IO.StreamWriter sw = new StreamWriter(@"..\..\..\Documents\log.txt", true))
            {
                sw.WriteLine("{0} Expected {1}, but got {2}", DateTime.Now, expected, received);
            }
        }


    }
}
