using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Screens
{
    class DisplayOrderScreen : Screen
    {
        public override void Display()
        {
            Console.Clear();
            DisplayHeader();
            string date = Input.GetDate("Please enter a date.");
            SetTestOrProd.MyOrderObject.LoadOrdersFromFile(date);

            Output.DisplayViewChooser();
            Console.WriteLine("Press enter to return to Home screen: ");
            Console.ReadLine();

            Screen next = new HomeScreen();
            next.JumpScreen(next);

        }


    }
}
