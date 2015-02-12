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
        public void GetStates()
        {
            using (StreamReader sr = new StreamReader("Taxes.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeState = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeState))
                    {
                        string[] WholeStateArray = WholeState.Split('|');

                        State newState = new State();

                        Enums.StateAbbreviations stateAbbrevs;
                        string stringStateAbbrevs;

                        stringStateAbbrevs = WholeStateArray[0];

                        if (Enums.StateAbbreviations.TryParse(stringStateAbbrevs, out stateAbbrevs))
                        {
                            //newState.StateAbbreviation = stateAbbrevs;
                            //if ((stateAbbrevs == "IA") || (stateAbbrevs == "MN") || (stateAbbrevs == "ND") ||(stateAbbrevs == "SD") ||(stateAbbrevs == "WI"))
                            //{
                            //then really output this to be used in the program
                            //}
                            //else
                            //{
                            //Console.WriteLine("We do not do business in that state; please contact a local dealer.");
                            //}

                        }



                        //Enums.StateNames stateName;
                        //    string stringStateName;

                        //    stringStateName = StripSpaces(WholeStateArray[1]);

                        //    if (Enums.StateNames.TryParse(stringStateName, out stateName))
                        //    {
                        //        newState.StateName = stateName;
                        //    }


                        //    Decimal taxRate;
                        //    if (Decimal.TryParse(WholeStateArray[2], out taxRate))
                        //    {
                        //        newState.TaxRate = Math.Round(taxRate * .01M, 2);
                        //    }

                        //    WorkingMemory.StateList.Add(newState);

                        //    var test = WorkingMemory.StateList;
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
    

