//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Remoting.Messaging;
//using System.Text;
//using System.Threading.Tasks;
//using FlooringMastery.Models;


<<<<<<< 706613dd45ad2e447b76b94a5adb2916067b889e
//namespace FlooringMastery.BLL
//{
//    public static class Validation
//    {
//        private static State GetState()
//        {
            
//            string stateAbbrev = new string(State.StateAbbreviation);
            
//            if (((((stateAbbrev == "MN") || "IA") || "WI") || "ND") || "SD")
//            {
//                return true;
//            }
//            else
//            {
//                Console.WriteLine("That isn't recognized as a state in which SWC currently operates.  \nPlease try again.");
//                return false;
//            }
         
//        }

//        private static Product GetProduct()
//        {
            
//        }

//        private static Order GetOrder()
//        {
=======
namespace FlooringMastery.BLL
{
    public static class Validation
    {
        private static string GetState(string stateAbbrev)
        {
            if ((stateAbbrev == "MN") || (stateAbbrev == "IA") || (stateAbbrev == "WI") || (stateAbbrev == "ND") || (stateAbbrev == "SD"))
            {
                return null;
            }
            else
            {
                return ("That isn't recognized as a state in which SWC currently operates.  \nPlease try again.");
            }
        }

        private static string GetProduct(string productOrdered)
        {
            if ((productOrdered == "Laminate") || (productOrdered == "Carpet") || (productOrdered == "Wood") || (productOrdered == "Tile"))
            {
                return null;
            }
            else
            {
                return ("That is not a product currently carried by SWC.  \nPlease try again.");
            }
        }

        private static List<String> GetOrder(Order myOrder)
        {
            var resultProd = GetProduct(myOrder.ProductType);
            List<String> errorProdMessages = new List<string>();
            errorProdMessages.Add(resultProd);

            var resultState = GetState(myOrder.StateAbbreviation);
            List<String> errorStateMessages = new List<string>();
            errorStateMessages.Add(resultState);
>>>>>>> 28e216b0ac756b9ce2bdf5d1bc9f70765cad6ac1
            
//        }
//    }
//}
