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
                Console.Write("There are no orders for that date. Press 1 to try another date or enter to return to main menu. ");
               //would need to add an option to try another date
                Console.ReadLine();
                Screen.JumpScreen(next);
            }
            Output.DisplayAllOrders();

            int orderNumber = Input.GetInteger("Enter an order number to edit: ");
            var myTestVariable = WorkingMemory.OrderList;
            if (orderNumber <= WorkingMemory.OrderList.Count)
            {
                var order = from o in WorkingMemory.OrderList.ToList()
                            where o.OrderNumber == orderNumber
                            select o;
                foreach (var k in order)
                {
                    ChangeOrder.EditEntireOrder(k);
                }
            }

            var doCommit = Input.QueryForCommit();
            ChangeOrder.CommitChangesToFile(doCommit);
            Output.DisplayCommitResults(doCommit);

            Screen.JumpScreen(next);

        }
    }
}
