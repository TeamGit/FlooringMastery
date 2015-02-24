using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class ProdOrders : IContainOrders
    {
        private List<Order> OrderDatabase { get; set; }
        
        public List<Order> LoadOrders(DateTime fileDate)
        {
            List<Order> orders = new List<Order>();
            
            return (orders);
        }

        public void SaveOrdersToFile(DateTime fileDate, List<Order> orders)
        {
            OrderDatabase.Clear();

            foreach (var order in orders)
            {
                OrderDatabase.Add(order);
            }
        }
    }
}
