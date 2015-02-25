using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    internal class ConfirmationScreen : Screen
    {
        private List<Order>  myOrders = new List<Order>(); 
        private DateTime myDateTime = new DateTime();

        public override void Display()
        {

        }

        public void Display(List<Order> orders, DateTime dateTimeObject)
        {
            DisplayHeader();

            myOrders.Clear();
            myDateTime = dateTimeObject;

            foreach (var order in orders)
            {
                Output.DisplayOrder(order);
                myOrders.Add(order);
            }

            Output.Prompt("The update list of orders is shown, would you like to save changes to file?");

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
                    case 'Y':
                    case 'y':
                        SetTestOrProd.MyOrderObject.SaveOrdersToFile(myDateTime, myOrders);
                        return new HomeScreen();
                    case 'N':
                    case 'n':
                        return new HomeScreen();

                }
            }

        }
    }
}