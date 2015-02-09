using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            TestData myData = new TestData();

            Order myOrder = myData.GetOrder();

            Output.DisplaySingleOrder(myOrder);
        }
    }
}
