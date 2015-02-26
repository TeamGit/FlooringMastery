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
            DisplayHeader();

            var date = Input.GetDate("Please enter the date from which you would like to edit an order.");
            Output.DisplayAllOrders(date);



            var orderNumbers = Calculation.GetAllOrderNumbers(date);
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(date);

            int orderNumberToEdit = Input.GetInt("Please enter a valid order number to edit.");

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
