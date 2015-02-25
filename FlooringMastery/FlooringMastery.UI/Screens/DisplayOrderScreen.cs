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
        
        public override void Display()
        {
            DisplayHeader();

            var date = Input.GetDate("Please enter the date for which to display orders.");
            Output.DisplayAllOrders(date);

            Output.PauseForReading();

            Screen HomeScreen = new HomeScreen();
            Screen.JumpScreen(HomeScreen);
        }

    }
}
