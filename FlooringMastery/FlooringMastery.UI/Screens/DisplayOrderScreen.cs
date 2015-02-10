using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Screens
{
    class DisplayOrderScreen : Screen
    {
        public override void Display()
        {
            Console.Clear();
            string date = Input.GetDate("Please enter a date.");
        }
    }
}
