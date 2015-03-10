using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class DisplayOrderScreen : Screen
    {
        protected override string GetScreenTitle()
        {
            return "DISPLAY ORDERS";
        }

        public override void Display()
        {
            var date = Input.GetDate("Enter the date of a file to display:");
           
            Output.DisplayAllOrders(date);

            Output.PauseForReading();

            Screen HomeScreen = new HomeScreen();
            Screen.JumpScreen(HomeScreen);
        }

    }
}
