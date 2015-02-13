using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery;

namespace FlooringMaster.Data
{
    public class TestStates : IContainStates
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
                        string[] WholeStateArray = WholeState.Split(',');
                        
                        State newState = new State();

                        Enums.StateNames stateName;
                        string stringStateName;

                        stringStateName = StripSpaces(WholeStateArray[0]);

                        if (Enums.StateNames.TryParse(stringStateName, out stateName))
                        {
                            newState.StateName = stateName;
                        }

                        Enums.StateAbbreviations stateAbbrevs;
                        if (Enums.StateAbbreviations.TryParse(WholeStateArray[1], out stateAbbrevs))
                        {
                            newState.StateAbbreviation = stateAbbrevs;
                        }

                        Decimal taxRate;
                        if (Decimal.TryParse(WholeStateArray[2], out taxRate))
                        {
                            newState.TaxRate = taxRate;
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
