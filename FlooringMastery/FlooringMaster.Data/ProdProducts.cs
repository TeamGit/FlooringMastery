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
       
        /// <summary>
        /// Read the product specification file, return a list of products.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            List<Product> myProductList = new List<Product>();

            using (StreamReader sr = new StreamReader(@"Products.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeProduct = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeProduct))
                    {
                        string[] WholeProductArray = WholeProduct.Split(',');

                        if (WholeProductArray[0] == "ProductType")
                        {
                            WholeProduct = sr.ReadLine();
                            if (!string.IsNullOrEmpty(WholeProduct))
                            {
                                WholeProductArray = WholeProduct.Split(',');
                            }

                        }
                        Product newProduct = new Product();

                        newProduct.ProductType = WholeProductArray[0];

                        Decimal costPerSquareFoot;
                        if (Decimal.TryParse(WholeProductArray[1], out costPerSquareFoot))
                        {
                            newProduct.CostPerSquareFoot = costPerSquareFoot;
                        }

                        Decimal laborCostPerSquareFoot;
                        if (Decimal.TryParse(WholeProductArray[2], out laborCostPerSquareFoot))
                        {
                            newProduct.LaborCostPerSquareFoot = laborCostPerSquareFoot;
                        }

                        myProductList.Add(newProduct);
                    }
                }
            return myProductList;

        }
        

    }
}
