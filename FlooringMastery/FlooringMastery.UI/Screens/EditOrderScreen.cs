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

            int orderNumberToEdit = Input.GetInt("Enter the number of the order to edit: ");

            if (orderNumbers.Contains(orderNumberToEdit))
            {
                var MyOrder = (from o in allOrders
                    where o.OrderNumber == orderNumberToEdit
                    select o).FirstOrDefault();

                Order newOrder = Edit.OrderEdit(MyOrder);

                Console.Clear();

                var validate = new ValidationScreen();
                
                validate.Display(newOrder, date, true);

            }
            else
            {
                var Home = new HomeScreen();
                Screen.JumpScreen(Home);
            }
        }
    }
}
