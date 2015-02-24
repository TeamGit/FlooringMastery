using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    public class ProdStates : IContainStates
    {
        /// <summary>
        /// Read a file containing state tax specifications, read each line into a state object and store it in a list
        /// </summary>
        public List<State> GetStates()
        {
            throw new NotImplementedException();
        }
    }
}
    

