using System;

namespace TheatreCMS3.Helpers
{
	public class TextHelpers
	{
		//Method to truncate the given string to the given length and return it with a trailing ellipsis.
		static public string Truncate(string text, int length)
		{
			return (length < text.Length) ? text.Substring(0, length) + "\u2026" : text;
		}
	}
}
