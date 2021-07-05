using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace KCompany_TestApp
{
    public static class InputValidators
    {
        public const int MinAgeRequired = 14;
        public const int MaxAgeRestriction = 100;
        public static bool AgeValidator(DateTime birthDate, int minAge = MinAgeRequired, int maxAge = MaxAgeRestriction)
        {
            if (minAge > maxAge) return false;
            int age = Tools.GetAgeBasedOnBirthDay(birthDate);
            return minAge <= age && age <= maxAge; 
        }

        public static bool IsNumberAndOrLatin(string s)
        {
            foreach (var ch in s) if (!char.IsDigit(ch) && !IsEnglishLetter(ch)) return false;
            return true;
        }

        #region Language specific methods
        public static bool IsRussianLetter(char c)
        {
            return 1040 <= c && c <= 1103;
        }

        public static bool InRussian(string s)
        {
            return s.All(c => IsRussianLetter(c));
        }

        public static bool IsEnglishLetter(char c)
        {
            return 65 <= c && c <= 122;
        }

        //public static bool InEnglish(string s)
        //{
        //    return s.All(c => IsEnglishLetter(c));
        //}

        #endregion
    }
}
