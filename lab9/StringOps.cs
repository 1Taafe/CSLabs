using System;
using System.Collections.Generic;
using System.Text;

namespace lab9
{
    public static class StringOps
    {
        public static string RemovePunctMarks(string myString)
        {
            myString = myString.Replace(".", string.Empty);
            myString = myString.Replace(",", string.Empty);
            myString = myString.Replace("!", string.Empty);
            myString = myString.Replace("?", string.Empty);
            return myString;
        }

        public static string AddQuestionMark(string myString) => myString + "?";
        
        public static string RemoveSpaces(string myString)
        {
            myString = myString.Replace(" ", "");
            return myString;
        }
        
        public static string ToUpperCase(string myString)
        {
            for (int i = 0; i < myString.Length; i++)
            {
                myString = myString.Replace(myString[i], char.ToUpper(myString[i]));
            }
            return myString;
        }
        
        public static string ToLowerCase(string myString)
        {
            for (int i = 0; i < myString.Length; i++)
            {
                myString = myString.Replace(myString[i], char.ToLower(myString[i]));
            }
            return myString;
        }

        public static string ImplementAllOps(string myString)
        {
            myString = RemovePunctMarks(myString);
            myString = AddQuestionMark(myString);
            myString = RemoveSpaces(myString);
            myString = ToUpperCase(myString);
            return myString;
        }
    }
}
