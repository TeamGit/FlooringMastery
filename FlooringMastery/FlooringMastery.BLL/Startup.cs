using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringMastery.BLL
{
    public static class Startup
    {
        public static void Start()
        {
            SetTestOrProd.SetTestOrProdMode(Properties.Settings.Default.TestMode);
            SetTestOrProd.MyStatesObject.GetStates();
            SetTestOrProd.MyProductObject.GetProducts();

            FileStream fs = new FileStream("log.txt", FileMode.OpenOrCreate);

        }
    }
}
