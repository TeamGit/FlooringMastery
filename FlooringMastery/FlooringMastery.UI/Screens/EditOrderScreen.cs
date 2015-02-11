using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class EditOrderScreen : Screen
    {

        public override void Display()
        {
            //DateTime newDateTime = new DateTime(2013,6,1);
            //SetTestOrProd.MyOrderObject.LoadOrdersFromFile("06012013");
            //Order myOrder = new Order();
            //var order = from o in WorkingMemory.OrderList.ToList()
            //    where o.OrderNumber == 1 
    
            //        select o;
            //foreach (var k in order)
            //{
            //    myOrder = k;
            //}

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

            int orderNumber = Input.GetInt("Please enter the order number you would like to edit: ");
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

        }
    }
}
