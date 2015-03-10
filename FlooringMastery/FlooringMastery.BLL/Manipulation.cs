﻿using System;
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
        /// <summary>
        /// Given an order object, serialize it and then desirialize it, returning a different order object with the same values as the input object.
        /// </summary>
        /// <param name="myOrder"></param>
        /// <returns></returns>
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
    }
}