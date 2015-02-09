using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class Input
    {
        public static string GetString(string prompt)
        {
            string input = null;

            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

            } while (string.IsNullOrEmpty(input));
            
            return input;
        }





    }
}
