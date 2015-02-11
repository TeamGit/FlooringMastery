using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class RemoveOrderScreen : Screen
    {

        public override void Display()
        {
            Console.Clear();
            DisplayHeader();
            string date = Input.GetDate("Please enter a date.");
            SetTestOrProd.MyOrderObject.LoadOrdersFromFile(date);
            Screen next = new HomeScreen();

            if (!WorkingMemory.OrderList.Any())
            {
                Console.WriteLine("There are no orders for that day. Press enter to return to Home screen.");
                Console.ReadLine();
                next.JumpScreen(next);
            }
            Output.DisplayAllOrders();

            int orderNumber = Input.GetInt("Please enter the order number you would like to delete: ");
            var myTestVariable = WorkingMemory.OrderList;
            if (orderNumber < WorkingMemory.OrderList.Count)
            {
                var order = from o in WorkingMemory.OrderList.ToList()
                    where o.OrderNumber == orderNumber
                    select o;
                foreach (var k in order)
                {
                WorkingMemory.OrderList.Remove(k);                    
                }
            }

            Console.Clear();
            Output.DisplayAllOrders();

            ChangeOrder.CommitChangesToFile(Input.QueryForCommit());

            next.JumpScreen(next);

        }
    }
}
