﻿namespace DrinksInfo;
public class Validator
{
    internal static bool IsStringValid(string stringInput)
    {
        if (String.IsNullOrEmpty(stringInput))
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
        if (String.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        foreach (char c in stringInput)
        {
            if (!Char.IsDigit(c))
                return false;
        }

        return true;
    }
}
