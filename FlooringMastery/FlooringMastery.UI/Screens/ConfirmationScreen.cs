using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMaster.Data;

namespace FlooringMastery.UI.Screens
{
    internal class ConfirmationScreen : Screen
    {
        private List<Order>  myOrders = new List<Order>(); 
        private DateTime myDateTime = new DateTime();
        private bool EditMode;
        private bool DeleteMode;
        private Order MyOrder = new Order();

        public override void Display()
        {

        }

        protected override string GetScreenTitle()
        {
            return "EDIT AN ORDER";
        }

        public void Display(Order order, DateTime dateTimeObject, bool editMode = true)
        {
            Console.Clear();
            this.DisplayHeader();

            EditMode = editMode;
            MyOrder = Manipulation.CloneOrder(order);
            myDateTime = dateTimeObject;
           
            if (!editMode)
            {
                MyOrder = Calculation.CalculateRemainingProperties(order);
            }

            Output.DisplayOrder(MyOrder, false);

            Output.Prompt("The new order is shown, would you like to save these changes to file?");

            Screen next = GetKeyPress();
            if (next != null)
                Screen.JumpScreen(next);
        }

        public void Display(List<Order> orders, DateTime dateTimeObject, bool deleteMode = false)
        {
            EditMode = false;
            DeleteMode = deleteMode;

            Console.Clear();
            this.DisplayHeader();
            
            myOrders.Clear();
            myDateTime = dateTimeObject;

            foreach (var order in orders)
            {
                Output.DisplayOrder(order);
                myOrders.Add(order);
            }

            Output.Prompt("The updated list of orders is shown, would you like to save changes to file?");

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
                            OldOrders.Remove(OldOrder);
                            myOrders = OldOrders;
                            myOrders.Add(MyOrder);
                        }
                        else if (DeleteMode)
                        {
                            
                        }
                        else
                        {
                            myOrders = SetTestOrProd.MyOrderObject.LoadOrders(myDateTime);
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