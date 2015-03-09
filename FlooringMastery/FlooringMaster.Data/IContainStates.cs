using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    /// <summary>
    /// State containing data objects
    /// </summary>
    public interface IContainStates
    {
        List<State> GetStates();
    }
}
