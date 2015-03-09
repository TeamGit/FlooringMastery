using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    /// <summary>
    /// Interface for the order containing data objects
    /// </summary>
    public interface IContainOrders
    {
        List<Order> LoadOrders(DateTime fileDate);

        void SaveOrdersToFile(DateTime fileDate, List<Order> orders);
    }


}
