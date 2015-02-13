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
         ///<summary>
         ///Read in the test product list we are using until we receive product specifications
         ///</summary>
        public void GetProducts()
        {
            using (StreamReader sr = new StreamReader("Products.txt"))
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

                        WorkingMemory.ProductList.Add(newProduct);

                    }
                }

        }

    }
}
