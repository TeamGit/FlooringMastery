using System.Collections.Generic;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    /// <summary>
    /// This class contains lists which hold the values of either the test or prod repos
    /// </summary>
    public static class WorkingMemory
    {
        public static List<State> StateList = new List<State>();

        public static List<Product> ProductList = new List<Product>(); 

        public static List<Order> OrderList = new List<Order>();

        public static string CurrentOrderFile;
    }
}
