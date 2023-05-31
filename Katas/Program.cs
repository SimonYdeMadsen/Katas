using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
	public class Program
	{
		//public static void Main(string[] args)
		//{ 
		//	int numberOfTeams = 14;

		//	var tournament = new Tournament.Tournament();

		//	var result = tournament.BuildMatchesTable(numberOfTeams);

		//	Console.WriteLine($"(Main)Result: ");
		//	foreach( var item in result )
		//	{
		//		Console.WriteLine(string.Join(", ", item));
		//	}

		//	var combinations = tournament.Combinations(tournament.GenerateTeams(numberOfTeams));

		//	List<(int, int)> flattenedList = result.SelectMany(list => list).ToList();

		//	int size = 0;
		//	int combinationCount = combinations.Count;
		//	foreach (var item in flattenedList)
		//	{
		//		size++;
		//		combinations.Remove(item);
		//		combinations.Remove((item.Item2, item.Item1));
		//	}
		//	Console.WriteLine($"Same size as combinations: {size == combinationCount}, {size} vs {combinationCount}");
		//	Console.WriteLine("Missing:" + string.Join(", ", combinations));
		//}

		public static void Main(string[] args)
		{

			int[][] queues =
			{
				new int[0], // G
				new int[0], // 1
				new int[]{5,5,5}, // 2
				new int[0], // 3
				new int[0], // 4
				new int[0], // 5
				new int[0], // 6
			};

			var result = Lift.Dinglemouse.TheLift(queues, 2);

			var truthWithCapacity5 = new[] { 0, 2, 5, 0 };
			var truthWithCapacity2 = new[] { 0, 2, 5, 2, 5, 0 };
			Console.WriteLine($"Lift took route: [{ string.Join(",", result)}]");
			Console.WriteLine($"Result status: {result.SequenceEqual(truthWithCapacity2)}");

			
		}


		public static bool Scramble(string longer, string shorter)
		{
			var shorterList = shorter.ToList();

			foreach (var c in longer)
			{
				shorterList.Remove(c);

			}
			return shorterList.Count == 0;

		}

		private void FindOddArrayEntry()
		{
			int[] sequence = { 1, 2, 2, 3, 3, 3, 4, 3, 3, 3, 2, 2, 1 };

			HashSet<int> potentials = new();

			foreach (int i in sequence)
			{
				if (potentials.Contains(i))
				{
					potentials.Remove(i);
				}
				else
				{
					potentials.Add(i);
				}

			}
			Console.WriteLine(potentials.FirstOrDefault());
		}

	}


}
