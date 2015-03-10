using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Screens
{
    class Edit
    {
        /// <summary>
        /// Given an order object, prompt the user with each current value and set a new value for each field in that order object.  Return the edited object.
        /// </summary>
        /// <param name="myOrder"></param>
        /// <returns></returns>
        public static Order OrderEdit(Order myOrder)
        {
            Order myShinyNewOrder = new Order();

            Console.WriteLine("");
            
            Output.PromptPlusCurrentValueStr("Customer Name:", myOrder.CustomerName);
            Console.SetCursorPosition("Customer Name:".Length, Console.CursorTop);
            myShinyNewOrder.CustomerName = Input.GetStringEdit(myOrder.CustomerName);

            Output.PromptPlusCurrentValueStr("State:", myOrder.StateAbbreviation);
            Console.SetCursorPosition("State:".Length, Console.CursorTop);
            myShinyNewOrder.StateAbbreviation = Input.GetStringEdit(myOrder.StateAbbreviation);

            Output.PromptPlusCurrentValueDec("Area:", myOrder.Area);
            Console.SetCursorPosition("Area:".Length, Console.CursorTop);
            myShinyNewOrder.Area = Input.GetDecimalEdit(myOrder.Area);

            Output.PromptPlusCurrentValueStr("Product:", myOrder.ProductType);
            Console.SetCursorPosition("Product:".Length, Console.CursorTop);
            myShinyNewOrder.ProductType = Input.GetStringEdit(myOrder.ProductType);

            Output.PromptPlusCurrentValueStr("Total Labor cost: ", myOrder.TotalLaborCost.ToString());
            Console.SetCursorPosition("Total Labor cost: ".Length, Console.CursorTop);
            myShinyNewOrder.TotalLaborCost = Input.GetDecimalEdit(myOrder.TotalLaborCost);
            
            Output.PromptPlusCurrentValueStr("Labor Cost Per Square Foot: ", myOrder.LaborCostPerSquareFoot.ToString());
            Console.SetCursorPosition("Labor Cost Per Square Foot: ".Length, Console.CursorTop);
            myShinyNewOrder.LaborCostPerSquareFoot = Input.GetDecimalEdit(myOrder.LaborCostPerSquareFoot);

            Output.PromptPlusCurrentValueStr("Total Material cost: ", myOrder.TotalMaterialCost.ToString());
            Console.SetCursorPosition("Total Material cost: ".Length, Console.CursorTop);
            myShinyNewOrder.TotalMaterialCost = Input.GetDecimalEdit(myOrder.TotalMaterialCost);

            Output.PromptPlusCurrentValueStr("Cost Per Square Foot: ", myOrder.CostPerSquareFoot.ToString());
            Console.SetCursorPosition("Cost Per Square Foot: ".Length, Console.CursorTop);
            myShinyNewOrder.CostPerSquareFoot = Input.GetDecimalEdit(myOrder.CostPerSquareFoot);

            Output.PromptPlusCurrentValueStr("Tax Rate: ", myOrder.TaxRate.ToString());
            Console.SetCursorPosition("Tax Rate: ".Length, Console.CursorTop);
            myShinyNewOrder.TaxRate = Input.GetDecimalEdit(myOrder.TaxRate);
          
            Output.PromptPlusCurrentValueStr("Total Tax cost: ", myOrder.TotalTax.ToString());
            Console.SetCursorPosition("Total Tax cost: ".Length, Console.CursorTop);
            myShinyNewOrder.TotalTax = Input.GetDecimalEdit(myOrder.TotalTax);

            myShinyNewOrder.OrderNumber = myOrder.OrderNumber;
            return myShinyNewOrder;
        }
    }
}
