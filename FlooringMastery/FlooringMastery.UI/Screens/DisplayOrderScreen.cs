using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class DisplayOrderScreen : Screen
    {
        
        public override void Display()
        {
            DisplayHeader();
            var dateString = Input.GetDate("Please enter the date for which to display orders: ");
            DateTime dateObject = new DateTime();
            if (Startup.TestMode == false)
            {
                dateObject = DateTime.Parse(dateString);
            }
           
            var allOrders = SetTestOrProd.MyOrderObject.LoadOrders(dateObject);

            foreach (var order in allOrders)
            {
                Output.DisplayOrder(order);
            }

            Output.PauseForReading();
        }
    }
}
