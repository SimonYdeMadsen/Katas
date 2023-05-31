using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
	public static class Pangram
	{
		private static HashSet<char> alphabet = new();
		static Pangram()
		{
			for (char c = 'a'; c <= 'z'; c++)
			{
				alphabet.Add(c);
			}
			
		}


		public static bool IsPangram(string sentence)
		{
			sentence = sentence.ToLower();
			HashSet<char> sentenceSet = sentence.ToHashSet();

			return (sentenceSet.Intersect(alphabet).ToHashSet().SetEquals(alphabet));
			
		}
	}
}
