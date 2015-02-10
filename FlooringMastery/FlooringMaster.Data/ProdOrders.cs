using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    class ProdOrders : IContainOrders
    {
        public Order GetOrder()
        {
            return new Order();
            //code goes here to pull from data file
        }

        public void LoadOrders()
        {
            throw new NotImplementedException();
        }


        public string LoadOrdersFromFile(string date)
        {
            throw new NotImplementedException();
        }


        public void AddOrderToFile(string myOrder)
        {
            throw new NotImplementedException();
        }


        public void SaveOrdersToFile(Order myOrder)
        {
            throw new NotImplementedException();
        }
    }
}
