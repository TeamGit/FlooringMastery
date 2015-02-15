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
    class RemoveOrderScreen : Screen
    {

        public override void Display()
        {
            Console.Clear();
            DisplayHeader();
            string date = Input.GetDate("Enter the date of the file to remove orders from that date: ");
            SetTestOrProd.MyOrderObject.LoadOrderFile(date);

            RejectEmptyDate();
            Console.WriteLine("\nALL ORDERS FOR {0}:", date);
            Console.WriteLine();              
            Output.DisplayAllOrders();

            int orderNumber = Input.GetInteger("Enter the order number to delete: ");
            var myTestVariable = WorkingMemory.OrderList;
            if (orderNumber <= WorkingMemory.OrderList.Count)
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
            Console.WriteLine("\nALL ORDERS FOR {0}:", date);
            Console.WriteLine();
            Output.DisplayAllOrders();

            var result = Input.QueryForCommit();
            ChangeOrder.CommitChangesToFile(result);
            Output.DisplayCommitResults(result);
            WorkingMemory.OrderList.Clear();
            
            Screen next = new HomeScreen();
            Screen.JumpScreen(next);

        }
        
    }
}
