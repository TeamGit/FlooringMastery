
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
            myOrder.TotalLaborCost = Math.Round(myOrder.Area * myOrder.OrderProduct.LaborCostPerSquareFoot, 2);

            myOrder.TotalMaterialCost = Math.Round(myOrder.Area * myOrder.OrderProduct.CostPerSquareFoot, 2);

            decimal subTotal = Math.Round(myOrder.TotalLaborCost + myOrder.TotalMaterialCost, 2);

            myOrder.TotalTax = Math.Round(subTotal * myOrder.OrderState.TaxRate, 2);

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
        /// Given an order object run the various edit methods on it's various properties
        /// </summary>
        /// <param name="myOrder"></param>
        public static void EditEntireOrder(Order myOrder)
        {
            myOrder.CustomerName = ChangeOrder.EditStringField("Current Customer Name: ", myOrder.CustomerName);
            myOrder.OrderState = ChangeOrder.EditStateField("Current State: ", myOrder.OrderState);            
            myOrder.OrderProduct = ChangeOrder.EditProductField("Current Product: ", myOrder.OrderProduct);            
            myOrder.Area = ChangeOrder.EditDecimalField("Current Area: ", myOrder.Area);
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
            return input;
        }

        /// <summary>
        /// Given a prompt and the current value of a State property, prompt the user to enter a new value or keep the old one by pressing enter
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static State EditStateField(string prompt, State currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.StateAbbreviation);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            string input = Console.ReadLine();
            State myState = new State();
            if (String.IsNullOrEmpty(input))
            {
                myState = currentValue;
            }

            if (WorkingMemory.StateList.Any(s => s.StateAbbreviation.ToString().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                var temp = from s in WorkingMemory.StateList
                       where s.StateAbbreviation.ToString().Equals(input, StringComparison.OrdinalIgnoreCase)
                       select s;

                foreach (var s in temp)
                {
                    myState = s;
                }

            }
            return myState;
        }

        /// <summary>
        /// Given a prompt and the current value of a Product property, prompt the user to enter a new value or keep the old one by pressing enter
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public static Product EditProductField(string prompt, Product currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ProductType);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            string input = Console.ReadLine();
            Product myProduct = new Product();
            myProduct = currentValue;
            

            if (WorkingMemory.ProductList.Any(s => s.ProductType.ToString().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                var temp = from s in WorkingMemory.ProductList
                           where s.ProductType.Equals(input, StringComparison.OrdinalIgnoreCase)
                           select s;

                
                foreach (var s in temp)
                {
                    myProduct = s;
                    return myProduct;
                }
                myProduct = currentValue;
            }
            Console.WriteLine("Product type is invalid, current type of {0} will be used.",currentValue.ProductType);
            return myProduct;
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

            return myDecimal;
        }

    }
}
