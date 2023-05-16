using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_List

{
    internal class Validator
    {
        internal static bool IsStringValid(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
            {
                return false;
            }
            foreach (char c in stringInput)
            {
                if (!Char.IsLetter(c) && c != '/' && c != ' ')
                    return false;
            }
            return true;
        }        
        public static bool IsIdValid(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
            {
                return false;
            }
            foreach(char c in stringInput)
            {
                if(!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
