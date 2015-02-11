using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public static class ChangeOrder
    {
        public static void AddOrderToList(Order myOrder)
        {
            WorkingMemory.OrderList.Add(myOrder);
        }

        public static void CommitAdditionsToFile(bool doCommmit, Order newOrder)
        {
            if (doCommmit)
            {
                WorkingMemory.OrderList.Add(newOrder);
                SetTestOrProd.MyOrderObject.SaveOrdersToFile();
            }   
        }

        public static void CommitChangesToFile(bool doCommmit)
        {
            if (doCommmit)
            {
                SetTestOrProd.MyOrderObject.SaveOrdersToFile();
            }
        }



    }
}
