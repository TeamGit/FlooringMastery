using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class Input
    {
        public static string GetDate(string prompt)
        {
            DateTime dateValue;
            do
            {
                Console.Write(prompt);
                Console.Write(DateTime.Now.ToString("MM/dd/yyyy"));
                Console.SetCursorPosition(prompt.Length, Console.CursorTop
                );
                string dateInput = Console.ReadLine();
                if (String.IsNullOrEmpty(dateInput))
                    dateInput = DateTime.Now.ToString("MM/dd/yyyy");
                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    string newString = dateValue.ToString("MMddyyyy");
                    return newString;
                }
                Console.WriteLine("Please enter the date in the format MM/DD/YYYY.");
             } while (true);
        }
    }
}
