using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public static class Output
    {
        /// <summary>
        /// Given an order object, display various values to the console
        /// </summary>
        /// <param name="myOrder"></param>
        public static void DisplaySingleOrder(Order myOrder)
        {
            Console.Clear();
            Console.WriteLine("Order Number: {0}", myOrder.OrderNumber);
            Console.WriteLine("Customer name: {0}",myOrder.CustomerName);
            Console.WriteLine("State name: {0}", myOrder.OrderState.StateName);
            Console.WriteLine("Area: {0} square feet",myOrder.Area);
            Console.WriteLine("Product Type: {0}",myOrder.OrderProduct.ProductType);
            Console.WriteLine("Total cost: {0:C}",myOrder.TotalCost);
            string lineOutputFormat = "{0,-30} {1,10:C}";
            Console.WriteLine(lineOutputFormat,"\tTotal Labor cost: ",myOrder.TotalLaborCost);
            Console.WriteLine(lineOutputFormat,"\tTotal Material cost: ",myOrder.TotalMaterialCost);
            Console.WriteLine(lineOutputFormat,"\tTotal Tax cost: ",myOrder.TotalTax);
        }

        public static void DisplayAllOrdersIndividually()
        {
            foreach (var o in WorkingMemory.OrderList)
            {
                DisplaySingleOrder(o);
                Console.WriteLine("Press enter for next order");
                Console.ReadLine();
            }
   
        }

        public static void DisplayAllOrders()
        {
            foreach (var o in WorkingMemory.OrderList)
            {
                Console.WriteLine("Order Number: {0}\tCustomer Name: {1}", o.OrderNumber, o.CustomerName);
                Console.WriteLine("*************");
            }
        }



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
