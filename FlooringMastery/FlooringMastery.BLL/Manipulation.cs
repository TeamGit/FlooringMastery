using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;


namespace FlooringMastery.BLL
{
    public class Manipulation
    {
        public static Order CloneOrder(Order myOrder)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms,myOrder);
                ms.Position = 0;

                return (Order)formatter.Deserialize(ms);
            }
        }

     

        public static string EditStringField(string currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue;
            }
            return input.Trim();
        }

    }
}
