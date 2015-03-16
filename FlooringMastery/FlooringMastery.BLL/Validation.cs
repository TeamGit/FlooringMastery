using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;


namespace FlooringMastery.BLL
{
    public static class Validation
    {
        /// <summary>
        /// Check to see if a given state abbreviation is contained in the current states list.  Return an error message if it's not.
        /// </summary>
        /// <param name="stateAbbrev"></param>
        /// <returns></returns>
        public static string GetState(string stateAbbrev)
        {
            List<State> states = SetTestOrProd.MyStatesObject.GetStates();
            List<String> stateAbbrevs = new List<string>();

            foreach (var state in states)
            {
                stateAbbrevs.Add(state.StateAbbreviation);
            }
            if (stateAbbrevs.Contains(stateAbbrev, StringComparer.CurrentCultureIgnoreCase))
            {
                return null;
            }
            else
            {
                return ("That isn't recognized as a state in which SWC currently operates.  \nPlease try again.");
            }
        }

        /// <summary>
        /// CHeck to see if a given product name is contained in the current products list.  Return an error message if it's not.
        /// </summary>
        /// <param name="productOrdered"></param>
        /// <returns></returns>
        public static string GetProduct(string productOrdered)
        {
            List<Product> products = SetTestOrProd.MyProductObject.GetProducts();
            List<String> productNames = new List<string>();

            foreach (var product in products)
            {
                productNames.Add(product.ProductType);
            }

            if (productNames.Contains(productOrdered, StringComparer.CurrentCultureIgnoreCase))
            {
                return null;
            }
            else
            {
                return ("That is not a product currently carried by SWC.  \nPlease try again.");
            }
        }

        /// <summary>
        /// Given an order object, run validation methods on it's fields.  Return any error messages generated as a list.
        /// </summary>
        /// <param name="myOrder"></param>
        /// <returns></returns>
        public static List<String> GetOrder(Order myOrder)
        {
            List<String> errorMessages = new List<string>();

            var resultProd = GetProduct(myOrder.ProductType);
            errorMessages.Add(resultProd);

            var resultState = GetState(myOrder.StateAbbreviation);
            errorMessages.Add(resultState);

            return errorMessages;
        }
    }
}
