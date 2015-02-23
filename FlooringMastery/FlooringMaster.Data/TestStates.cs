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


        List<State> IContainStates.GetStates()
        {
            List<State> states = new List<State>();

            State myState = new State();

            myState.StateAbbreviation = "MN";
            myState.StateName = "Minnesota";
            myState.TaxRate = 6.25m;

            states.Add(myState);

            myState.StateAbbreviation = "IA";
            myState.StateName = "Iowa";
            myState.TaxRate = 6.75m;

            states.Add(myState);

            myState.StateAbbreviation = "WI";
            myState.StateName = "Wisconsin";
            myState.TaxRate = 5.75m;

            states.Add(myState);

            myState.StateAbbreviation = "ND";
            myState.StateName = "North Dakota";
            myState.TaxRate = 4.00m;

            states.Add(myState);

            myState.StateAbbreviation = "SD";
            myState.StateName = "South Dakota";
            myState.TaxRate = 5.05m;

            states.Add(myState);

            return states;
        }
    }
}
