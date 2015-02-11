﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public interface IContainOrders
    {
        string LoadOrdersFromFile(string date);

        void SaveOrdersToFile();
    }
}
