using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.Models;
using FlooringMastery.UI.Screens;

namespace FlooringMastery.UI
{
    /// <summary>
    /// Output class for displaying to console
    /// </summary>
    public static class Output
    {

        /// <summary>
        /// Initilaize the console with the homescreen
        /// </summary>
        public static void Go()
        {
            Screen myScreen = new HomeScreen();
            myScreen.Display();
        }

        /// <summary>
        /// Given an order object, display various values to the console
        /// </summary>
        /// <param name="myOrder"></param>
        public static void DisplaySingleOrder(Order myOrder)
        {
            Console.Clear();
            if (myOrder.OrderNumber != 0)
                Console.WriteLine("Order Number: {0}", myOrder.OrderNumber);
            Console.WriteLine("Customer name: {0}",myOrder.CustomerName);

            var tempState =
                WorkingMemory.StateList.FirstOrDefault(
                    p =>
                        p.StateAbbreviation.ToString()
                            .Equals(myOrder.StateAbbreviation, StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine("State name: {0}", StateDictionaryClass.AllStates[tempState.StateAbbreviation]);

            Console.WriteLine("Area: {0} square feet",myOrder.Area);

            Console.WriteLine("Product Type: {0}",myOrder.ProductType);
            Console.WriteLine("Total cost: {0:C}",myOrder.TotalCost);
            string lineOutputFormat = "{0,-30} {1,10:C}";
            Console.WriteLine(lineOutputFormat,"\tTotal Labor cost: ",myOrder.TotalLaborCost);
            Console.WriteLine(lineOutputFormat,"\tTotal Material cost: ",myOrder.TotalMaterialCost);
            Console.WriteLine(lineOutputFormat,"\tTotal Tax cost: ",myOrder.TotalTax);
        }

        /// <summary>
        /// Call DisplaySingleOrder on every order in the current order list, pausing in between each order
        /// </summary>
        public static void DisplayAllOrdersIndividually()
        {
            foreach (var o in WorkingMemory.OrderList)
            {
                DisplaySingleOrder(o);
                Console.WriteLine("Press enter for next order");
                Console.ReadLine();
            }
        }


        /// <summary>
        /// Display a stub of each order all at the same time
        /// </summary>
        public static void DisplayAllOrders()
        {
            foreach (var o in WorkingMemory.OrderList)
            {
                Console.WriteLine("Order Number: {0} Customer Name: {1}", o.OrderNumber, o.CustomerName);
                Console.WriteLine("*************");
            }
        }
        

        /// <summary>
        /// Given a bool indicating if changes have been committed, output a message informing the user
        /// </summary>
        /// <param name="commit"></param>
        public static void DisplayCommitResults(bool commit)
        {
            if (commit)
                Console.WriteLine("Changes have been committed to file.");
            else
            {
                Console.WriteLine("Changes have been discarded.");
            }
            Console.WriteLine("(enter to continue)");
            Console.ReadLine();
        }

        /// <summary>
        /// Allow the user to choose between viewing orders individually or in a list, then call the appropriate method
        /// </summary>
        public static void DisplayViewChooser()
        {
            bool looper = true;
            do
            {
                Console.WriteLine("Enter (1) for detailed view, (2) for complete list");

                string viewType = Console.ReadLine();

                if (viewType == "1")
                {
                    Output.DisplayAllOrdersIndividually();
                    looper = false;
                }

                if (viewType == "2")
                {
                    Output.DisplayAllOrders();
                    looper = false;
                }
            } while (looper);
        }
    }
}
