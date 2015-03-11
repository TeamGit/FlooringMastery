using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.UI.Screens;


namespace FlooringMastery.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = (DateTime.Parse("01/01/0001"));
            ProdOrders myOrders = new ProdOrders();
            var listResult = myOrders.LoadOrders(date);
            var result = listResult.FirstOrDefault();

            Output.Go();
        }
    }
}
