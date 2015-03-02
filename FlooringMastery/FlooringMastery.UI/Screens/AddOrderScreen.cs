using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class AddOrderScreen : Screen
    {
        protected override string GetScreenTitle()
        {
            return "ADD AN ORDER";
        }

        public override void Display()
        {
            var date = Input.GetDate("Enter the date of the order: ");
            
            Order newOrder = Input.GetOrder();
            Console.Clear();

            Output.DisplayOrder(newOrder, false);

            var confirm = new ConfirmationScreen();

            confirm.Display(newOrder, date);
            Output.PauseForReading();

            Screen HomeScreen = new HomeScreen();
            Screen.JumpScreen(HomeScreen);
        }

    }
}
