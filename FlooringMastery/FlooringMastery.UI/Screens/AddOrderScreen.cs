﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class AddOrderScreen : Screen
    {
        public override void Display()
        {
            Console.Clear();
            if (String.IsNullOrEmpty(WorkingMemory.CurrentOrderFile))
            {
                Console.WriteLine();
                SetTestOrProd.MyOrderObject.LoadOrdersFromFile(Input.GetDate("here is where a prompt will go when we pick one"));
                Console.WriteLine();
            }
            Order newOrder = Input.QueryUserForOrder();

            Console.Clear();
            Output.DisplaySingleOrder(newOrder);

            var doCommit = Input.QueryForCommit();

            AddOrder.CommitChangesToFile(doCommit, newOrder);
            Output.DisplayCommitResults(doCommit);

            Screen next = new HomeScreen();
            next.JumpScreen(next);

        }
    }
}
