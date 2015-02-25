using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class DisplayOrderScreen : Screen
    {
        private Order _currentOrder;

        /// <summary>
        /// Newing up the DisplayOrderScreen requires you to specify an order
        /// </summary>
        /// <param name="myOrder"></param>
        public DisplayOrderScreen(Order myOrder)
        {
            _currentOrder = Manipulation.CloneOrder(myOrder);
        }

        public override void Display()
        {
            DisplayHeader();
            Output.DisplayOrder(_currentOrder);
        }
    }
}
