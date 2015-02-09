using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery;

namespace FlooringMaster.Data
{
    public class TestStates : IContainStates
    {
        public void GetStates()
        {
            using (StreamReader sr = new StreamReader("TestStates.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeState = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeState))
                    {
                        string[] WholeStateArray = WholeState.Split(',');
                        
                        State newState = new State();

                        Enums.StateNames stateName;
                        string stringStateName;

                        stringStateName = StripSpaces(WholeStateArray[1]);

                        if (Enums.StateNames.TryParse(WholeStateArray[1], out stateName))
                        {
                            newState.StateName = stateName;
                        }

                        Enums.StateAbbreviations stateAbbrevs;
                        if (Enums.StateAbbreviations.TryParse(WholeStateArray[0], out stateAbbrevs))
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
