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
        private bool EditMode;
        private Order MyOrder = new Order();

        public override void Display()
        {

        }

        public void Display(Order order, DateTime dateTimeObject)
        {
            DisplayMainHeader();
            EditMode = true;
            MyOrder = Manipulation.CloneOrder(order);
            myDateTime = dateTimeObject;

            Output.DisplayOrder(order);

            Output.Prompt("The edited order is shown, would you like to save changes to file?");

            Screen next = GetKeyPress();
            if (next != null)
                Screen.JumpScreen(next);
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
                        if (EditMode)
                        {
                            var OldOrders = SetTestOrProd.MyOrderObject.LoadOrders(myDateTime);
                            var OldOrder = OldOrders.Where(o => o.OrderNumber == MyOrder.OrderNumber).FirstOrDefault();
                            myOrders.Remove(OldOrder);
                            myOrders.Add(MyOrder);
                        }
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