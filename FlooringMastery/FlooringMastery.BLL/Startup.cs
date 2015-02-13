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
        /// <summary>
        /// Check the application config settings, initialize the workingmemory repos from their source files, create a log file if one doesn't exist.
        /// </summary>
        public static void Start()
        {
            SetTestOrProd.SetTestOrProdMode(Properties.Settings.Default.TestMode);
            SetTestOrProd.MyStatesObject.GetStates();
            SetTestOrProd.MyProductObject.GetProducts();
            
            FileStream fs = new FileStream(@"..\..\..\Documents\log.txt", FileMode.OpenOrCreate);
            fs.Close();
        }
    }
}
