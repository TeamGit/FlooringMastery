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
        protected override string GetScreenTitle()
        {
            return "EDIT AN ORDER";
        }

        public override void Display()
        {
            var date = Input.GetDate("Enter the date of the order: ");
            Output.DisplayAllOrders(date);



            var orderNumbers = Calculation.GetAllOrderNumbers(date);
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(date);

            //going to work on code for changed input request here
            int orderNumberToEdit = Input.GetInt("There are no orders for that date. Press 1 to try" +
                                                 "\nanother date or enter to return to main menu.");

            if (orderNumbers.Contains(orderNumberToEdit))
            {
                var MyOrder = (from o in allOrders
                    where o.OrderNumber == orderNumberToEdit
                    select o).FirstOrDefault();

                Order newOrder = Edit.OrderEdit(MyOrder);

                var confirm = new ConfirmationScreen();

                confirm.Display(newOrder, date);

            }
            else
            {
                var Home = new HomeScreen();
                Screen.JumpScreen(Home);
            }
        }
    }
}
