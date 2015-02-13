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
        /// Read a file, read each line into a state object and store it in a list
        /// </summary>
        public void GetStates()
        {
            using (StreamReader sr = new StreamReader(@"..\..\..\Documents\Taxes.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeState = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeState))
                    {
                        
                        string[] WholeStateArray = WholeState.Split('|');

                        State newState = new State();
                        
                                              
                        Enums.StateAbbreviations stateAbbrevs;
                        if (Enums.StateAbbreviations.TryParse(WholeStateArray[0], out stateAbbrevs))
                        {
                            newState.StateAbbreviation = stateAbbrevs;
                            if (StateDictionaryClass.AllStates.ContainsKey(stateAbbrevs))
                            {
                                newState.StateName = StateDictionaryClass.AllStates[stateAbbrevs];
                            }
                        }
                        else
                            continue;

                        Decimal taxRate;
                        if (Decimal.TryParse(WholeStateArray[2], out taxRate))
                        {
                            newState.TaxRate = taxRate/100;
                        }

                        WorkingMemory.StateList.Add(newState);
                    }
                }
        }

        /// <summary>
        /// Given a string return the string with spaces removed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripSpaces(string input)
        {
            string output = "";
            foreach (var c in input)
            {
                if (c != ' ')
                {
                    output += c;
                }
            }
            return output;
        }
    }
}
    

