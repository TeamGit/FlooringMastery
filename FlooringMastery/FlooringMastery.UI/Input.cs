using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class Input
    {
        /// <summary>
        /// Given a prompt, continually prompt the user until they enter a non-empty string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
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

        /// <summary>
        /// take a string parse it into a date time, format it, and return it as a new string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetDate(string prompt)
        {
            DateTime dateValue;
           
            do
            {
                Console.WriteLine(prompt);
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out dateValue))
                {
                    string newString = dateValue.ToString("MMddyyyy");
                    return newString;
                }
            } while (true);

            return null;
        }

        //public static string GetDate(string prompt)
        //{
        //    string input;

        //    do
        //    {
        //        Console.WriteLine(prompt);
        //        input = Console.ReadLine();

        //        if (!String.IsNullOrEmpty(input))
        //        {
        //            String[] DateInputArray = input.Split('/');

        //            if (DateInputArray.Length == 3)
        //            {
        //                if (CheckMonth(DateInputArray[0]))
        //                {
        //                    if (CheckDay(DateInputArray[1]))
        //                    {
        //                        if (CheckYear(DateInputArray[2]))
        //                        {
        //                            return input;
        //                        }
        //                    }
        //                }

        //            }
        //        }
        //        break;
        //    } while (true);
        //    return null;
        //}


        //private static bool CheckMonth(string monthString)
        //{
        //    if (monthString.Length == 2)
        //    {
        //        int month;
        //        if (int.TryParse(monthString, out month))
        //        {
        //            if ((month >= 01) && (month <= 12))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private static bool CheckDay(string dayString)
        //{
        //   if (dayString.Length == 2)
        //    {
        //        int day;
        //        if (int.TryParse(dayString, out day))
        //        {
        //            if ((day >= 1) && (day <= 31))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private static bool CheckYear(string yearString)
        //{
        //    if (yearString.Length == 4)
        //    {
        //        int year;
        //        if (int.TryParse(yearString, out year))
        //        {
        //            if (year > 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}
