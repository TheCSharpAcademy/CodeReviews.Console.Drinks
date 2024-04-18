using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.samggannon
{
    internal class Validator
    {
        internal static bool IsIdValid(string? drink)
        {
            if (String.IsNullOrEmpty(drink))
            {
                return false;
            }

            foreach (char c in drink)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool IsStringValid(string? category)
        {
            if (String.IsNullOrEmpty(category))
            { 
                return false;
            }

            foreach (char c in category)
            {
                if (!Char.IsLetter(c) && c != '/' && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
