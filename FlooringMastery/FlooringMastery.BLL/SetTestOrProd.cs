using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMaster.Data;

namespace FlooringMastery.BLL
{

    public static class SetTestOrProd
    {
        public static IContainOrders MyOrderObject;
        public static IContainStates MyStatesObject;
        public static IContainProducts MyProductObject;

        /// <summary>
        /// Given a bool indicating test mode, create either test or prod objects to access the repos
        /// </summary>
        /// <param name="TestMode"></param>
        public static void SetTestOrProdMode(bool TestMode)
        {
            if (TestMode == true)
            {
                //MyOrderObject = new TestOrders();
                MyStatesObject = new TestStates();
                MyProductObject = new TestProducts();
            }
            else
            {
                MyOrderObject = new ProdOrders();
                MyStatesObject = new ProdStates();
                MyProductObject = new ProdProducts();
            }
        }
    }
}
