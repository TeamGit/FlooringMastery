using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class ProdOrders : IContainOrders
    {

        /// <summary>
        /// Read in multiple orders from a text file
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>

        /// <summary>
        /// Write the current working memory list of orders to file.
        /// </summary>

        /// <summary>
        /// given a string, build a valid path and prefix the filename with Orders_ and append .txt
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FileNameBuilder(string input)
        {
            string filename = input;
            if (!filename.EndsWith(".txt", true, CultureInfo.CurrentCulture))
            {
                filename = input + ".txt";
            }
            if (!filename.StartsWith(@"..\..\..\Documents\Orders_"))
            {
                filename = @"..\..\..\Documents\Orders_" + filename;
            }
            else
            {
                filename = input;
            }
            return filename;
        }

        public List<Order> LoadOrders(DateTime fileDate)
        {
            throw new NotImplementedException();
        }

        public void SaveOrdersToFile(DateTime fileDate, List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
