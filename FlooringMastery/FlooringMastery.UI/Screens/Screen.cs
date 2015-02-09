using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Screens
{
    abstract class Screen
    {
        public abstract void Display();

        public void JumpScreen(Screen nextScreen)
        {
            nextScreen.Display();
        }
    }
}
