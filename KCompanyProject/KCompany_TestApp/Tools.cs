using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCompany_TestApp
{
    public static class Tools
    {
        /// <summary>
        /// Converts first letter to uppercase (and others to lowercase if needed)
        /// </summary>
        /// <param name="s">Converted string</param>
        /// <param name="onlyTheFirstLetterCapital">If true, other letters will be converted to lower case</param>
        /// <returns></returns>
        public static string ToOfficialNameFormat(string s, bool onlyTheFirstLetterCapital = true)
        {
            if (string.IsNullOrEmpty(s)) return s;

            char[] otherLetters = s.Remove(0, 1).ToCharArray();
            if (onlyTheFirstLetterCapital)
            {
                for (int i = 0; i < otherLetters.Length; ++i)
                    otherLetters[i] = char.ToLower(otherLetters[i]);
            }
            return char.ToUpper(s[0]) + new string(otherLetters);
        }

        public static int GetAgeBasedOnBirthDay(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.DayOfYear > DateTime.Now.DayOfYear) age--;
            return age;
        }

    }
}
