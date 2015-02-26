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
            DisplayHeader();

            var date = Input.GetDate("Please enter the date from which you would like to remove an order.");
            Output.DisplayAllOrders(date);



            var orderNumbers = Calculation.GetAllOrderNumbers(date);
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(date);
            
            int orderNumberToDelete = Input.GetInt("Please enter a valid order number to delete.");

            if (orderNumbers.Contains(orderNumberToDelete))
            {
                orderNumbers.Remove(orderNumberToDelete);

                var allOrdersMinusOne = (from o in allOrders
                                        where orderNumbers.Contains(o.OrderNumber)
                                        select o).ToList();

                var confirm = new ConfirmationScreen();

                confirm.Display(allOrdersMinusOne, date);

            }
            else
            {
                var Home = new HomeScreen();
                Screen.JumpScreen(Home);
            }

        }
    }
}
