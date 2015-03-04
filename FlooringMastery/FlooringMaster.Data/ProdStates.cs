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
        /// <returns></returns>
        List<State> IContainStates.GetStates()
        {
            //Are we creatign a new class in the BLL for this or will the new list product be located in one of the 
            //existing classes in the BLL?  Or is this not needed anymore?  Same question at the bottom of this class
            //WorkingMemory.StateList.Clear();

            using (StreamReader sr = new StreamReader(@"..\..\..\Documents\Taxes.txt"))
                while (!sr.EndOfStream)
                {
                    string WholeState = sr.ReadLine();
                    if (!string.IsNullOrEmpty(WholeState))
                    {
                        string[] WholeStateArray = WholeState.Split('|');

                        State newState = new State();

                        if (WholeStateArray[0] == "StateAbbreviation")
                        {
                            WholeState = sr.ReadLine();
                            if (!string.IsNullOrEmpty(WholeState))
                            {
                                WholeStateArray = WholeState.Split('|');
                            }
                        }

                        if (WholeStateArray[1] == "StateName")
                        {
                            WholeState = sr.ReadLine();
                            if (!string.IsNullOrEmpty(WholeState))
                            {
                                WholeStateArray = WholeState.Split('|');
                            }
                        }

                        Decimal taxRate;
                        if (Decimal.TryParse(WholeStateArray[2], out taxRate))
                        {
                            newState.TaxRate = taxRate/100;
                        }

                        //Are we creatign a new class in the BLL for this or will the new list product be located in one of the existing classes in the BLL? Or is this not needed anymore?
                        //WorkingMemory.StateList.Add(newState);
                    }
                }
            return new List<State>();
        }


    }
}
    

