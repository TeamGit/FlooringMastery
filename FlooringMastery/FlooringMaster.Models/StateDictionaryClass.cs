using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    /// <summary>
    /// Dictionary containing the abbreviation and name enums and tying them together
    /// </summary>
    public static class StateDictionaryClass
    {
        public static Dictionary<Enums.StateAbbreviations, Enums.StateNames> AllStates = new Dictionary
            <Enums.StateAbbreviations, Enums.StateNames>()
        {
            {Enums.StateAbbreviations.AL, Enums.StateNames.Alabama},
            {Enums.StateAbbreviations.AK, Enums.StateNames.Alaska},
            {Enums.StateAbbreviations.AR, Enums.StateNames.Arkansas},
            {Enums.StateAbbreviations.AZ, Enums.StateNames.Arizona},
            {Enums.StateAbbreviations.CA, Enums.StateNames.California},
            {Enums.StateAbbreviations.CO, Enums.StateNames.Colorado},
            {Enums.StateAbbreviations.CT, Enums.StateNames.Connecticut},
            {Enums.StateAbbreviations.DE, Enums.StateNames.Delaware},
            {Enums.StateAbbreviations.FL, Enums.StateNames.Florida},
            {Enums.StateAbbreviations.GA, Enums.StateNames.Georgia},
            {Enums.StateAbbreviations.HI, Enums.StateNames.Hawaii},
            {Enums.StateAbbreviations.ID, Enums.StateNames.Idaho},
            {Enums.StateAbbreviations.IA, Enums.StateNames.Iowa},
            {Enums.StateAbbreviations.IL, Enums.StateNames.Illinois},
            {Enums.StateAbbreviations.IN, Enums.StateNames.Indiana},
            {Enums.StateAbbreviations.KS, Enums.StateNames.Kansas},
            {Enums.StateAbbreviations.KY, Enums.StateNames.Kentucky},
            {Enums.StateAbbreviations.LA, Enums.StateNames.Louisiana},
            {Enums.StateAbbreviations.ME, Enums.StateNames.Maine},
            {Enums.StateAbbreviations.MD, Enums.StateNames.Maryland},
            {Enums.StateAbbreviations.MA, Enums.StateNames.Massachusetts},
            {Enums.StateAbbreviations.MI, Enums.StateNames.Michigan},
            {Enums.StateAbbreviations.MN, Enums.StateNames.Minnesota},
            {Enums.StateAbbreviations.MO, Enums.StateNames.Missouri},
            {Enums.StateAbbreviations.MT, Enums.StateNames.Montana},
            {Enums.StateAbbreviations.NC, Enums.StateNames.NorthCarolina},
            {Enums.StateAbbreviations.ND, Enums.StateNames.NorthDakota},
            {Enums.StateAbbreviations.NE, Enums.StateNames.Nebraska},
            {Enums.StateAbbreviations.NH, Enums.StateNames.NewHampshire},
            {Enums.StateAbbreviations.NJ, Enums.StateNames.NewJersey},
            {Enums.StateAbbreviations.NM, Enums.StateNames.NewMexico},
            {Enums.StateAbbreviations.NV, Enums.StateNames.Nevada},
            {Enums.StateAbbreviations.NY, Enums.StateNames.NewYork},
            {Enums.StateAbbreviations.OH, Enums.StateNames.Ohio},
            {Enums.StateAbbreviations.OK, Enums.StateNames.Oklahoma},
            {Enums.StateAbbreviations.OR, Enums.StateNames.Oregon},
            {Enums.StateAbbreviations.PA, Enums.StateNames.Pennsylvania},
            {Enums.StateAbbreviations.RI, Enums.StateNames.RhodeIsland},
            {Enums.StateAbbreviations.SC, Enums.StateNames.SouthCarolina},
            {Enums.StateAbbreviations.SD, Enums.StateNames.SouthDakota},
            {Enums.StateAbbreviations.TN, Enums.StateNames.Tennessee},
            {Enums.StateAbbreviations.TX, Enums.StateNames.Texas},
            {Enums.StateAbbreviations.UT, Enums.StateNames.Utah},
            {Enums.StateAbbreviations.VT, Enums.StateNames.Vermont},
            {Enums.StateAbbreviations.VA, Enums.StateNames.Virginia},
            {Enums.StateAbbreviations.WA, Enums.StateNames.Washington},
            {Enums.StateAbbreviations.WV, Enums.StateNames.WestVirginia},
            {Enums.StateAbbreviations.WI, Enums.StateNames.Wisconsin},
            {Enums.StateAbbreviations.WY, Enums.StateNames.Wyoming}
        };
    }
}
