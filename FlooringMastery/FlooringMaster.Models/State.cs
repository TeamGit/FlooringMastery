using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class State
    {
        public Enums.StateAbbreviations StateAbbreviation { get; set; }

        public Enums.StateNames StateName { get; set; }
        
        public decimal TaxRate { get; set; }
    }
}
