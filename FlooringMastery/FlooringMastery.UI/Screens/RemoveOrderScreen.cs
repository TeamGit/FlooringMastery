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
        protected override string GetScreenTitle()
        {
            return "REMOVE AN ORDER";
        }

        public override void Display()
        {
            var date = Input.GetDate("Enter the date of the file to remove: ");
            Output.DisplayAllOrders(date);


            var orderNumbers = Calculation.GetAllOrderNumbers(date);
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(date);
            
            int orderNumberToDelete = Input.GetInt("Enter a valid order number to delete.");

            if (orderNumbers.Contains(orderNumberToDelete))
            {
                orderNumbers.Remove(orderNumberToDelete);

                var allOrdersMinusOne = (from o in allOrders
                                        where orderNumbers.Contains(o.OrderNumber)
                                        select o).ToList();

                var confirm = new ConfirmationScreen();

                confirm.Display(allOrdersMinusOne, date, true);

            }
            else
            {
                var Home = new HomeScreen();
                Screen.JumpScreen(Home);
            }

        }
    }
}
