﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
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
           
            do
            {
                Console.WriteLine(prompt);
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    string newString = dateValue.ToString("MMddyyyy");
                    return newString;
                }
            } while (true);

            return null;
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

        private static State GetState()
        {
            bool gotState = false;
            Enums.StateAbbreviations stateAbbrevs;

            do
            {
                string tempState = GetString("Please enter the state abbreviation");
                
                if (Enums.StateAbbreviations.TryParse(tempState, out stateAbbrevs))
                {
                    gotState = true;
                }
            } while (!gotState);
            
            var temp = from s in WorkingMemory.StateList
                       where s.StateAbbreviation == stateAbbrevs
                       select s;

            State myState = new State();
            
            foreach (var s in temp)
            {
                myState = s;
            }
            return myState;
        }

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
                where p.ProductType == tempProduct
                select p;

            foreach (var p in temp)
            {
                newProduct = p;
            }
            return newProduct;
        }

        //public static string GetDate(string prompt)
        //{
        //    string input;

        //    do
        //    {
        //        Console.WriteLine(prompt);
        //        input = Console.ReadLine();

        //        if (!String.IsNullOrEmpty(input))
        //        {
        //            String[] DateInputArray = input.Split('/');

        //            if (DateInputArray.Length == 3)
        //            {
        //                if (CheckMonth(DateInputArray[0]))
        //                {
        //                    if (CheckDay(DateInputArray[1]))
        //                    {
        //                        if (CheckYear(DateInputArray[2]))
        //                        {
        //                            return input;
        //                        }
        //                    }
        //                }

        //            }
        //        }
        //        break;
        //    } while (true);
        //    return null;
        //}


        //private static bool CheckMonth(string monthString)
        //{
        //    if (monthString.Length == 2)
        //    {
        //        int month;
        //        if (int.TryParse(monthString, out month))
        //        {
        //            if ((month >= 01) && (month <= 12))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private static bool CheckDay(string dayString)
        //{
        //   if (dayString.Length == 2)
        //    {
        //        int day;
        //        if (int.TryParse(dayString, out day))
        //        {
        //            if ((day >= 1) && (day <= 31))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private static bool CheckYear(string yearString)
        //{
        //    if (yearString.Length == 4)
        //    {
        //        int year;
        //        if (int.TryParse(yearString, out year))
        //        {
        //            if (year > 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}
