using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class ProdProducts : IContainProducts
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            return (products);
        }
    }
}
