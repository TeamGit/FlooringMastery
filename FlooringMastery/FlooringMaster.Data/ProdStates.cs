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
        /// Read a file containing state tax specifications, read each line into a state object and return it in a list
        /// </summary>
        /// <returns></returns>
        public List<State> GetStates()
        {
            List<State> myStateList = new List<State>();

            using (StreamReader sr = new StreamReader(@"Taxes.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeState = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeState))
                    {
                        if (WholeState.StartsWith("#"))
                            continue;

                        string[] WholeStateArray = WholeState.Split('|');

                        State newState = new State();

                        if (WholeStateArray[0] == "StateAbbreviation")
                            continue;

                        newState.StateAbbreviation = WholeStateArray[0];
                        newState.StateName = WholeStateArray[1];
                        newState.TaxRate = Decimal.Parse(WholeStateArray[2]);
                        
                        myStateList.Add(newState);
                    }
                }
            return myStateList;
        }


    }
}
    

