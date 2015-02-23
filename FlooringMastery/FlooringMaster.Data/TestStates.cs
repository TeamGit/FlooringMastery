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
        /// return a list of State objects to use for testing
        /// </summary>
        /// <returns></returns>
        public List<State> GetStates()
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
