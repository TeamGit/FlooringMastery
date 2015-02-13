using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.Globalization;


namespace FlooringMastery.BLL
{
    public static class ChangeOrder
    {
        public static Order CalculateRemainingProperties(Order myOrder)
        {
            myOrder.TotalLaborCost = Math.Round(myOrder.Area * myOrder.OrderProduct.LaborCostPerSquareFoot, 2);

            myOrder.TotalMaterialCost = Math.Round(myOrder.Area * myOrder.OrderProduct.CostPerSquareFoot, 2);

            decimal subTotal = Math.Round(myOrder.TotalLaborCost + myOrder.TotalMaterialCost, 2);

            myOrder.TotalTax = Math.Round(subTotal * myOrder.OrderState.TaxRate, 2);

            myOrder.TotalCost = Math.Round(subTotal + myOrder.TotalTax, 2);

            return myOrder;
        }

        public static void AddOrderToList(Order myOrder)
        {
            WorkingMemory.OrderList.Add(myOrder);
        }

        public static void CommitAdditionsToFile(bool doCommmit, Order newOrder)
        {
            if (doCommmit)
            {
                WorkingMemory.OrderList.Add(newOrder);
                SetTestOrProd.MyOrderObject.SaveOrdersToFile();
            }   
        }

        public static void CommitChangesToFile(bool doCommmit)
        {
            if (doCommmit)
            {
                SetTestOrProd.MyOrderObject.SaveOrdersToFile();
            }
        }

        public static void EditEntireOrder(Order myOrder)
        {
            myOrder.CustomerName = ChangeOrder.EditStringField("Current Customer Name: ", myOrder.CustomerName);
            myOrder.OrderState = ChangeOrder.EditStateField("Current State: ", myOrder.OrderState);            
            myOrder.OrderProduct = ChangeOrder.EditProductField("Current Product: ", myOrder.OrderProduct);            
            myOrder.Area = ChangeOrder.EditDecimalField("Current Area: ", myOrder.Area);
        }

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


        public static Product EditProductField(string prompt, Product currentValue)
        {
            Console.Write(prompt);
            Console.Write(currentValue.ProductType);
            Console.SetCursorPosition(prompt.Length, Console.CursorTop);
            string input = Console.ReadLine();
            Product myProduct = new Product();
            if (String.IsNullOrEmpty(input))
            {
                myProduct = currentValue;
            }

            if (WorkingMemory.ProductList.Any(s => s.ProductType.ToString().Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                var temp = from s in WorkingMemory.ProductList
                           where s.ProductType.Equals(input, StringComparison.OrdinalIgnoreCase)
                           select s;

                foreach (var s in temp)
                {
                    myProduct = s;
                }

            }
            return myProduct;
        }


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

        /// <summary>
        /// given a string, build a valid path and prefix the filename with Orders_ and append .txt
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FileNameBuilder(string input)
        {
            string filename = input;
            if (!filename.EndsWith(".txt", true, CultureInfo.CurrentCulture))
            {
                filename = input + ".txt";
            }
            if (!filename.StartsWith(@".\Orders\Orders_"))
            {
                filename = @".\Orders\Orders_" + filename;
            }
            else
            {
                filename = input;
            }
            return filename;
        }
    }
}
