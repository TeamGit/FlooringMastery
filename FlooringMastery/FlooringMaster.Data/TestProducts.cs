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
        List<Product> IContainProducts.GetProducts()
        {
            List<Product> products = new List<Product>();

            Product myProduct = new Product();

            myProduct.ProductType = "Carpet";
            myProduct.CostPerSquareFoot = 2.25m;
            myProduct.LaborCostPerSquareFoot = 2.10m;

            products.Add(myProduct);

            myProduct.ProductType = "Laminate";
            myProduct.CostPerSquareFoot = 1.75m;
            myProduct.LaborCostPerSquareFoot = 2.10m;

            products.Add(myProduct);

            myProduct.ProductType = "Tile";
            myProduct.CostPerSquareFoot = 3.50m;
            myProduct.LaborCostPerSquareFoot = 4.15m;

            products.Add(myProduct);

            myProduct.ProductType = "Wood";
            myProduct.CostPerSquareFoot = 3.50m;
            myProduct.LaborCostPerSquareFoot = 4.15m;

            products.Add(myProduct);

            return products;
        }
    }
}
