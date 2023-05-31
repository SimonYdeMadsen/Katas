using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
	internal static class ArrayFilter
	{
		public static int[] Filter(int[] a, int[] b)
		{
			var list = a.ToList();
			foreach (var item in b)
			{
				list.RemoveAll(x => x == item);
			}

			return list.ToArray();
		}
	}
}
