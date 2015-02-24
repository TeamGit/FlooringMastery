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
            State myState1 = new State();
            State myState2 = new State();
            State myState3 = new State();
            State myState4 = new State();


            myState.StateAbbreviation = "MN";
            myState.StateName = "Minnesota";
            myState.TaxRate = 6.25m;

            states.Add(myState);

            myState1.StateAbbreviation = "IA";
            myState1.StateName = "Iowa";
            myState1.TaxRate = 6.75m;

            states.Add(myState1);

            myState2.StateAbbreviation = "WI";
            myState2.StateName = "Wisconsin";
            myState2.TaxRate = 5.75m;

            states.Add(myState2);

            myState3.StateAbbreviation = "ND";
            myState3.StateName = "North Dakota";
            myState3.TaxRate = 4.00m;

            states.Add(myState3);

            myState4.StateAbbreviation = "SD";
            myState4.StateName = "South Dakota";
            myState4.TaxRate = 5.05m;

            states.Add(myState4);

            return states;
        }
    }
}
