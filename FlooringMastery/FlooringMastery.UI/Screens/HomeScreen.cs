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
            DisplayHeader();
            Console.WriteLine("ORDER MANAGEMENT: MAIN MENU\n");
            Console.WriteLine("Select from options 1-5:");
            Console.WriteLine();
            Console.WriteLine("\t1. Display Orders");
            Console.WriteLine("\t2. Add an Order");
            Console.WriteLine("\t3. Edit an Order");
            Console.WriteLine("\t4. Remove an Order");
            Console.WriteLine("\t5. Quit");

            Screen next = GetKeyPress();
            if (next != null)
                Screen.JumpScreen(next);
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
                    case '3':
                        return new EditOrderScreen();
                    case '4':
                        return new RemoveOrderScreen();
                    case '5':
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}
