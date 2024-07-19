namespace Drinks.kjanos89
{
    public class Validation
    {
        public bool IsValidString(string str)
        {
            if(String.IsNullOrEmpty(str)) return false;
            foreach (char c in str)
            {
                if(!Char.IsLetter(c) && c!='/'&&c!=' ') return false;
            }
            return true;
        }
    }
}
