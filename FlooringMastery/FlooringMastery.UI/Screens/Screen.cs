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
        public void Run()
        {
            Console.Clear();
            this.DisplayHeader();
            this.Display();
        }

        public abstract void Display();

        protected virtual void DisplayHeader()
        {
            string companyName = "SWC Corp";
            if (Startup.TestMode)
                Console.WriteLine("********TEST MODE ENABLED**********");
            Console.WriteLine("{0," + (Console.WindowWidth + companyName.Length) / 2 + "}", companyName);

            string screenTitle = this.GetScreenTitle();
            if (screenTitle != null)
                Console.WriteLine("{0," + (Console.WindowWidth + screenTitle.Length) / 2 + "}", screenTitle);
            Console.WriteLine();
        }

        protected virtual string GetScreenTitle()
        {
            return null;
        }
        
        public static void JumpScreen(Screen nextScreen)
        {
            nextScreen.Run();
        }

     

    }
}
