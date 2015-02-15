using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class EditOrderScreen : Screen
    {

        public override void Display()
        {
            Console.Clear();
            DisplayHeader();
            string date = Input.GetDate("Enter the date of a file to edit orders from that date: ");
            SetTestOrProd.MyOrderObject.LoadOrderFile(date);
            Screen next = new HomeScreen();

            if (!WorkingMemory.OrderList.Any())
            {
                Console.Write("There are no orders for that date. Press 1 to try\nanother date or enter to return to main menu. ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    next = new EditOrderScreen();
                }
                Screen.JumpScreen(next);
            }
            Output.DisplayAllOrders();

            int orderNumber = Input.GetOrderNumber("Enter an order number to edit: ");
            var myTestVariable = WorkingMemory.OrderList;
            Order order;
            if (orderNumber <= WorkingMemory.OrderList.Count)
            {
                var oldOrder = WorkingMemory.OrderList.FirstOrDefault(o => o.OrderNumber == orderNumber);
                order = ChangeOrder.EditEntireOrder(oldOrder);
                var index = WorkingMemory.OrderList.IndexOf(oldOrder);
                WorkingMemory.OrderList[index] = order;
                Console.Clear();
                Output.DisplaySingleOrder(order);
            }

            var doCommit = Input.QueryForCommit();
            ChangeOrder.CommitChangesToFile(doCommit);
            Output.DisplayCommitResults(doCommit);

            Screen.JumpScreen(next);

        }
    }
}
