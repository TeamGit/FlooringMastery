using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Screens
{
    class HomeScreen : Screen
    {
        public override void Display()
        {
            Startup.Start();
            Console.Clear();
            string companyName = "Welcome to SWC Corp!";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + companyName.Length) / 2 + "}", companyName));
            string slogan = "Where the floor is the limit";
            Console.WriteLine(String.Format("{0," + (Console.WindowWidth + slogan.Length) / 2 + "}", slogan));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please select an option 1-5:");
            Console.WriteLine("\t1. Display Orders");
            Console.WriteLine("\t2. Add an Order");
            Console.WriteLine("\t3. Edit an Order");
            Console.WriteLine("\t4. Remove an Order");
            Console.WriteLine("\t5. Quit");

            Screen next = GetKeyPress();
            if (next != null)
                next.JumpScreen(next);
        }

        private Screen GetKeyPress()
        {
            while (true)
            {
                ConsoleKeyInfo myKeyPress = Console.ReadKey(true);

                switch (myKeyPress.KeyChar)
                {
                    case '1':
                        return new DisplayOrderScreen();
                    case '2':
                        return new AddOrderScreen();
                    //case '3':
                    //    return new EditOrderScreen();
                    //case '4':
                    //    return new RemoveOrderScreen();
                    case '5':
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}
