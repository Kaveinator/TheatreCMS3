using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        //takes in string and integer that defines the max length of the string
        static string TruncateStringByChar(string String, int charLength)
        {
            if (String.Length > charLength)
            {
                String = String.Substring(0, charLength) + "...";
            }
            return String;
            //returns a truncated string with '...' at end if input string exceeded character length specified by integer value, will truncate to integer value char length
        }
    }
}

//TESTING THIS METHOD : CREATE A NEW CONSOLE APP AND PASTE THIS CODE IN PLACE OF THE CODE WITHIN THE PROGRAM.CS FILE 

//class Program
//{
//    static string TruncateStringByChar(string String, int charLength)
//    {
//        if (String.Length > charLength)
//        {
//            String = String.Substring(0, charLength) + "...";
//        }
//        return String;
//        //returns a truncated string with '...' at end if input string exceeded character length specified by integer value, will truncate to integer value char length
//    }
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Type something. Will truncate to 3 max chars + ellipses");
//        string input = Console.ReadLine();
//        string truncString = TruncateStringByChar(input, 3);
//        Console.WriteLine(truncString);
//        Console.ReadKey();

//        Console.WriteLine("Type something. Will truncate to 7 max chars + ellipses");
//        string input2 = Console.ReadLine();
//        string truncString2 = TruncateStringByChar(input, 7);
//        Console.WriteLine(truncString2);
//        Console.ReadKey();
//    }
//}