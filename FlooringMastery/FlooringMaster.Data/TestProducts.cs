using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
   
    public class TestProducts : IContainProducts
    {
        /// <summary>
        /// Return a static list of products to use for testing the application
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            Product myProduct = new Product();
            Product myProduct1 = new Product();
            Product myProduct2 = new Product();
            Product myProduct3 = new Product();

            myProduct.ProductType = "Carpet";
            myProduct.CostPerSquareFoot = 2.25m;
            myProduct.LaborCostPerSquareFoot = 2.10m;

            products.Add(myProduct);

            myProduct1.ProductType = "Laminate";
            myProduct1.CostPerSquareFoot = 1.75m;
            myProduct1.LaborCostPerSquareFoot = 2.10m;

            products.Add(myProduct1);

            myProduct2.ProductType = "Tile";
            myProduct2.CostPerSquareFoot = 3.50m;
            myProduct2.LaborCostPerSquareFoot = 4.15m;

            products.Add(myProduct2);

            myProduct3.ProductType = "Wood";
            myProduct3.CostPerSquareFoot = 3.50m;
            myProduct3.LaborCostPerSquareFoot = 4.15m;

            products.Add(myProduct3);

            return products;
        }
    }
}
