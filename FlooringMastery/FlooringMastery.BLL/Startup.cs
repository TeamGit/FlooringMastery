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
        public static bool firstRun = true;

        /// <summary>
        /// set bool TestMode based on the app settings
        /// </summary>
        public static bool TestMode = Properties.Settings.Default.TestMode;

        /// <summary>
        /// Set test or prod mode, based on a bool obtained from app settings
        /// </summary>
        public static void Start()
        {
            SetTestOrProd.SetTestOrProdMode(TestMode);
            firstRun = false;
        }
    }
}
