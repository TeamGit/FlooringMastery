using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class Input
    {
        public static DateTime GetDate(string prompt)
        {
            DateTime dateValue;
            do
            {
                Output.DatePrompt(prompt);

                string dateInput = Console.ReadLine();
                if (String.IsNullOrEmpty(dateInput))
                    dateInput = DateTime.Now.ToString("MM/dd/yyyy");
                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    return dateValue;
                }
                Console.WriteLine("Please enter the date in the format MM/DD/YYYY.");
            } while (true);
        }


        public static int GetInt(string prompt)
        {
            int myInt;
            do
            {
                Output.Prompt(prompt);
                string stringInput = Console.ReadLine();
                if (String.IsNullOrEmpty(stringInput))
                {
                    continue;
                }

                if (int.TryParse(stringInput, out myInt))
                {
                    return myInt;
                }
            } while (true);
        }

        public static string GetStringEdit(string currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue;
            }
            return input.Trim();
        }

        public static int GetIntEdit(int currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue.ToString();
            }
            int outputInt;
            if (int.TryParse(input, out outputInt))
            {
                return outputInt;
            }
            return currentValue;
        }

        public static decimal GetDecimalEdit(decimal currentValue)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                input = currentValue.ToString();
            }
            decimal outputDecimal;
            if (decimal.TryParse(input, out outputDecimal))
            {
                return outputDecimal;
            }
            return currentValue;
        }
    }
}
