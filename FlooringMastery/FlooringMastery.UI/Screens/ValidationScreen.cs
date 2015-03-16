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
    class ValidationScreen : Screen
    {
        protected override string GetScreenTitle()
        {
            return "VALIDATE ORDER";
        }

        public override void Display()
        {

        }

        public void Display(Order myOrder, DateTime myDateTime, bool editMode)
        {
            List<string> errorMessages = Validation.GetOrder(myOrder);

            if (errorMessages.Any())
            {
                bool errors = false;
                foreach (var message in errorMessages)
                {
                    if (message != null)
                    {
                        Console.WriteLine(message);
                        errors = true;
                    }

                    else
                        continue;
                }
                if (errors)
                {
                    Output.PauseForReading();
                    HomeScreen Home = new HomeScreen();
                    Screen.JumpScreen(Home);
                }
                else
                {
                    ConfirmationScreen confirmation = new ConfirmationScreen();
                    confirmation.Display(myOrder, myDateTime, editMode);
                }

            }
        }

    }

}

