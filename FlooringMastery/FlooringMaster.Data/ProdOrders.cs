﻿using System;
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

        public void GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
