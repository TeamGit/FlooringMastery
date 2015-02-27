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

            //there needs to be some cases for if the date is not found, giving the user an option 
            //like the message "There's no order for that date. Press 1 to try another date or 
            //enter to return to main menu." and then the switch cases for that.

            var orderNumbers = Calculation.GetAllOrderNumbers(date);
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(date);

            int orderNumberToEdit = Input.GetInt("Enter the number of the order to edit: ");

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
