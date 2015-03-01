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

        public static string GetStringEdit(string currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue;
            }
            return input.Trim();
        }

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

        //public static Order GetOrder()
        //{
        //    Order myOrder = new Order();
                      
        //    myOrder.CustomerName = (GetStringEdit("Enter the customer name: ")).ToUpper();

        //    State tempState = GetState();

        //    myOrder.StateAbbreviation = tempState.StateAbbreviation.ToString();
        //    myOrder.TaxRate = tempState.TaxRate;

        //    Product tempProduct = GetProduct();
        //    myOrder.ProductType = tempProduct.ProductType.ToString();
        //    myOrder.CostPerSquareFoot = tempProduct.CostPerSquareFoot;
        //    myOrder.LaborCostPerSquareFoot = tempProduct.LaborCostPerSquareFoot;

        //    myOrder.Area = GetDecimalEdit("Enter the area of the floor in feet squared: ");
            
        //    myOrder = ChangeOrder.CalculateRemainingProperties(myOrder);

        //    return myOrder;
        //}

        //public static State GetState()
        //{
        //    bool gotState = false;
        //    string tempState;

        //    do
        //    {
        //        tempState = GetStringEdit("Enter the state abbreviation: ");

        //        if (ProdStates.any(s => s.StateAbbreviation.ToString().Equals(tempState, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            gotState = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("That isn't recognized as a state in which SWC currently operates.\nPlease try again.");
        //            Console.WriteLine("SWC currently operates in the following states: ");
        //            foreach (var state in WorkingMemory.StateList)
        //            {
        //                Console.Write("{0}    ", state.StateAbbreviation);
        //            }
        //            Console.WriteLine();
        //        }

        //        Log("state abbreviation", tempState);

        //    } while (!gotState);

        //    var temp = from s in WorkingMemory.StateList
        //               where s.StateAbbreviation.ToString().Equals(tempState, StringComparison.OrdinalIgnoreCase)
        //               select s;

        //    State myState = new State();

        //    foreach (var s in temp)
        //    {
        //        myState = s;
        //    }
        //    return myState;
        //}
    }
}
