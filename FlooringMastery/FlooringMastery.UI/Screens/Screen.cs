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

        public void DisplayMainHeader()
        {
            Console.Clear();
            string companyName = "Welcome to SWC Corp";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + companyName.Length) / 2 + "}", companyName));
            string slogan = "Where the floor is the limit";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + slogan.Length) / 2 + "}", slogan));
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DisplaySecondaryHeader(Screen calledScreen)
        {
            Console.Clear();
            string companyName = "SWC Corp";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + companyName.Length) / 2 + "}", companyName));
            string currentScreen = calledScreen.ToString();
            string tagline = "";
            switch (currentScreen)
            {
                case "AddOrderScreen":
                    tagline = "ADD ORDER";
                    break;
                case "DisplayOrderScreen":
                    tagline = "DISPLAY ORDER";
                    break;
                case "EditOrderScreen":
                    tagline = "EDIT ORDER";
                    break;
                case "RemoveOrderScreen":
                    tagline = "REMOVE ORDER";
                    break;
                default:
                    DisplayMainHeader();
                    break;
            }
            if (tagline != "")
                Console.WriteLine(String.Format("{0," + (Console.WindowWidth + tagline.Length) / 2 + "}", tagline));

        }
        
        
        public static void JumpScreen(Screen nextScreen)
        {
            nextScreen.Display();
        }

     

    }
}
