using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sadklouds.Drinks
{
    public static class Validator
    {
        public static bool IsStringValid(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != '/' && c != ' ') return false;
            }

            return true;
        }

        public static bool isIdValid(string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return false;

            foreach(char c in input)
            {
                if(!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
