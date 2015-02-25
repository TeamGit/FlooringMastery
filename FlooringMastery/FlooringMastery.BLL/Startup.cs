using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;


namespace FlooringMastery.BLL
{
    public static class Startup
    {
        public static bool TestMode = Properties.Settings.Default.TestMode;

        public static void Start()
        {
            SetTestOrProd.SetTestOrProdMode(TestMode);
            SetTestOrProd.MyStatesObject.GetStates();
            SetTestOrProd.MyProductObject.GetProducts();
        }
    }
}
