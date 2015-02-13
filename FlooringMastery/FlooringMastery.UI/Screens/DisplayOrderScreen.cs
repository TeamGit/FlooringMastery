using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Screens
{
    class DisplayOrderScreen : Screen
    {
        public override void Display()
        {
            Console.Clear();
            DisplayHeader();
            string date = Input.GetDate("Enter the date of a file to display orders from that date: ");
            WorkingMemory.OrderList.Clear();
            SetTestOrProd.MyOrderObject.LoadOrderFile(date);

            RejectEmptyDate();


            Output.DisplayViewChooser();
            Console.Write("Press enter to return to the main menu.");
            Console.ReadLine();

            Screen next = new HomeScreen();
            Screen.JumpScreen(next);

        }

    }
}
