using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Screens
{
    abstract class Screen
    {
        public abstract void Display();

        public void DisplayHeader()
        {
            string companyName = "Welcome to SWC Corp";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + companyName.Length) / 2 + "}", companyName));
            string slogan = "Where the floor is the limit";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + slogan.Length) / 2 + "}", slogan));
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void JumpScreen(Screen nextScreen)
        {
            nextScreen.Display();
        }

     

    }
}
