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
        /// Read the product specification file, store the list in working memory.
        /// </summary>
        /// <returns></returns>
        List<Product> IContainProducts.GetProducts()
        {
            //Are we creatign a new class in the BLL for this or will the new list product be located in one of the 
            //existing classes in the BLL?  Or is this not needed anymore?  Same question at the bottom of this class
            //WorkingMemory.ProductList.Clear();
            using (StreamReader sr = new StreamReader(@"..\..\..\Documents\Products.txt"))
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

                        //Is this moving to calculation in the BLL?

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

                        //Are we creatign a new class in the BLL for this or will the new list product be located in one of the existing classes in the BLL? Or is this not needed anymore?
                        //WorkingMemory.ProductList.Add(newProduct);

                    }
                }
            return new List<Product>();

        }
        

    }
}
