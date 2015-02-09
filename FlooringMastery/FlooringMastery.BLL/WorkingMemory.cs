using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    /// <summary>
    /// This class contains lists which hold values read in from repositories
    /// </summary>
    public static class WorkingMemory
    {
        public static List<State> StateList = new List<State>();

        public static List<Product> ProductList = new List<Product>(); 

        public static List<Order> OrderList = new List<Order>();
    }
}
