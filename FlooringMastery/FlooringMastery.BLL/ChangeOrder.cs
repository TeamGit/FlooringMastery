
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.Globalization;
using FlooringMaster.Data;


namespace FlooringMastery.BLL
{
    public static class ChangeOrder
    {
        /// <summary>
        /// Given a partially populated Order object, fill in the rest of the properties
        /// </summary>
        /// <param name="myOrder"></param>
        /// <returns></returns>
        public static Order CalculateRemainingProperties(Order myOrder)
        {
            Product myProduct =
                WorkingMemory.ProductList.FirstOrDefault(p => p.ProductType.Equals(myOrder.ProductType));

            myOrder.LaborCostPerSquareFoot = myProduct.LaborCostPerSquareFoot;

            myOrder.CostPerSquareFoot = myProduct.CostPerSquareFoot;

            var myState = 
                WorkingMemory.StateList.FirstOrDefault(s => s.StateAbbreviation.ToString().Equals(myOrder.StateAbbreviation));

            myOrder.TaxRate = myState.TaxRate;

            myOrder.TotalLaborCost = Math.Round(myOrder.Area * myOrder.LaborCostPerSquareFoot, 2);

            myOrder.TotalMaterialCost = Math.Round(myOrder.Area * myOrder.CostPerSquareFoot, 2);

            decimal subTotal = Math.Round(myOrder.TotalLaborCost + myOrder.TotalMaterialCost, 2);

            myOrder.TotalTax = Math.Round(subTotal * myOrder.TaxRate, 2);

            myOrder.TotalCost = Math.Round(subTotal + myOrder.TotalTax, 2);

            return myOrder;
        }

        /// <summary>
        /// Given an Order object, add it to the working memory list
        /// </summary>
        /// <param name="myOrder"></param>
        public static void AddOrderToList(Order myOrder)
        {
            WorkingMemory.OrderList.Add(myOrder);
        }

        /// <summary>
        /// Given an order and a bool indicating if a new order should be committed to file either add the order to working memory and save to file, or do nothing
        /// </summary>
        /// <param name="doCommmit"></param>
        /// <param name="newOrder"></param>
        public static void CommitAdditionsToFile(bool doCommmit, Order newOrder)
        {
            if (doCommmit)
            {
                WorkingMemory.OrderList.Add(newOrder);
                SetTestOrProd.MyOrderObject.SaveOrdersToFile();
            }   
        }

        /// <summary>
        /// Given a bool indicating if changes should be written to file either do so or do nothing
        /// </summary>
        /// <param name="doCommmit"></param>
        public static void CommitChangesToFile(bool doCommmit)
        {
            if (doCommmit)
            {
                SetTestOrProd.MyOrderObject.SaveOrdersToFile();
            }
        }

        /// <summary>
        /// Given an order object run the various edit methods on it's various properties then return it as an Order object
        /// </summary>
        /// <param name="myOrder"></param>
        public static Order EditEntireOrder(Order myOrder)
        {
            myOrder.CustomerName = ChangeOrder.EditStringField("Current Customer Name: ", myOrder.CustomerName);
            myOrder.StateAbbreviation = ChangeOrder.EditStateStringAbbrevField("Current State: ", myOrder.StateAbbreviation);            
            myOrder.ProductType = ChangeOrder.EditProductStringField("Current Product: ", myOrder.ProductType);            
            myOrder.Area = ChangeOrder.EditDecimalField("Current Area: ", myOrder.Area);
            ChangeOrder.CalculateRemainingProperties(myOrder);

            return myOrder;
        }

        /// <summary>
        /// Given a prompt and the current value of a string property, prompt the user to enter a new value or keep the old one by pressing enter
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static string EditStringField(string prompt, string currentValue)
        { 
            Console.Write(prompt);
            Console.Write(currentValue);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue;
            }
            return input.Trim();
        }

        /// <summary>
        /// Given a prompt and the current value of an Order object string property holding a state abbreviation, prompt the user to enter a new value or keep the old one by pressing enter
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static string EditStateStringAbbrevField(string prompt, string currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            string input = StripSpaces(Console.ReadLine());
            if (String.IsNullOrEmpty(input))
            {
                return currentValue;
            }
            string StateAbbrevString;

            if (
                WorkingMemory.StateList.Any(
                    s => s.StateAbbreviation.ToString().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                StateAbbrevString = input;
            }
            else
            {
                Console.WriteLine("That wasn't recognized as state in which SWC operates.\nThe previous value of {0} will be used.",currentValue);
                return currentValue;
            }


            var temp =
                WorkingMemory.StateList.FirstOrDefault(
                    s => s.StateAbbreviation.ToString().Equals(input, StringComparison.CurrentCultureIgnoreCase));

            return temp.StateAbbreviation.ToString();
        }

        /// <summary>
        /// Given a prompt and the current value of an Order object ProductType string property, prompt the user to enter a new value or keep the old one by pressing enter
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static string EditProductStringField(string prompt, string currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            string input = StripSpaces(Console.ReadLine());
            
            string myProduct = currentValue;

            var temp =
                WorkingMemory.ProductList.FirstOrDefault(
                    p => p.ProductType.Equals(input, StringComparison.CurrentCultureIgnoreCase));

            if (temp != null)
            {
                return temp.ProductType;
            }
            else
            {
                Console.WriteLine("Current type of {0} will be used.", currentValue);
                return myProduct;
            }
            
        }

        /// <summary>
        /// Given a prompt and the current value of a Decimal property, prompt the user to enter a new value or keep the old one by pressing enter
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static decimal EditDecimalField(string prompt, decimal currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ToString());
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            decimal myDecimal; 

            string input = Console.ReadLine();
            if (Decimal.TryParse(input, out myDecimal))
            {
                return myDecimal;
            }
            myDecimal = currentValue;
            Console.WriteLine("Value of {0} will be used for the product area.",myDecimal);

            return myDecimal;
        }

        /// <summary>
        /// Given a string return the string with spaces removed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripSpaces(string input)
        {
            string output = "";
            foreach (var c in input)
            {
                if (c != ' ')
                {
                    output += c;
                }
            }
            return output;
        }

    }
}
