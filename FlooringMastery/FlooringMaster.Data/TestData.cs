using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class TestData : IContainData
    {
        /// <summary>
        /// Returns a order object
        /// </summary>
        /// <returns></returns>
        public Order GetOrder()
        {
            Order myOrder = new Order();
            
            myOrder.OrderNumber = 1;
            myOrder.CustomerName = "Wise";
            myOrder.OrderState.TaxRate = 6.25M;
            myOrder.OrderState.StateAbbreviation = Enums.StateAbbreviations.AK;
            myOrder.OrderState.StateName = Enums.StateNames.Alaska;
            myOrder.Area = 100.00M;
            myOrder.OrderProduct.ProductType = "Wood";
            myOrder.OrderProduct.CostPerSquareFoot = 5.15M;
            myOrder.OrderProduct.LaborCostPerSquareFoot = 4.75M;
            myOrder.TotalMaterialCost = 515.00M;
            myOrder.TotalLaborCost = 475.00M;
            myOrder.TotalTax = 61.88M;
            myOrder.TotalCost = 1051.88M;

            return myOrder;

        }
    }
}
