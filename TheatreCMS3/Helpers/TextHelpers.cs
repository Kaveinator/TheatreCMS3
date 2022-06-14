using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers    
    {
        public static string CharacterLimit(string Input, int Length)
        {
            if (Input.Length < Length) return Input;
            int index = Input.IndexOf(' ', Length);
            return Input.Substring(0, index) + "...";
        }
    }
}