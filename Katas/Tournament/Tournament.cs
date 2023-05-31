using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Tournament
{
    public class Tournament
    {

		private int[]? teams;

		public (int, int)[][] BuildMatchesTable(int numberOfTeams)
		{
			teams = GenerateTeams(numberOfTeams);
			var matchesTable = new List<List<(int, int)>>();

			var teamsOne = teams.ToList();
			var teamsTwo = teams.ToList();
			teamsTwo.Reverse();
			teamsTwo.RemoveAt(teamsTwo.Count - 1);

			int upperBound = numberOfTeams % 2 == 0 ? numberOfTeams : numberOfTeams + 1;
			
			for (int r = 1; r < upperBound; r++)
			{
				var round = new List<(int, int)>();
				for (int index = 0; index < (Math.Ceiling((double)numberOfTeams)/2); index++)
				{
					var t = (teamsOne[index], teamsTwo[index]);
					if (t.Item1 != t.Item2)
					{
						round.Add(t);
					}
					
				}
				matchesTable.Add(round);

				teamsOne.Insert(1, teamsOne.ElementAt(teamsOne.Count-1));
				teamsOne.RemoveAt(teamsOne.Count - 1);

				teamsTwo.Add(teamsTwo.ElementAt(0));
				teamsTwo.RemoveAt(0);

			}
			(int, int)[][] formattedResult = matchesTable.Select(list => list.ToArray()).ToArray();

			return formattedResult;
		}
		

		public int[] GenerateTeams(int numberOfTeams)
		{
			return Enumerable.Range(1, numberOfTeams).ToArray();
		}

		public HashSet<(int, int)> Combinations(int[] teams)
		{
			var matches = new HashSet<(int, int)>();

			var remainingTeams = teams.ToList();
			foreach (var team in teams)
			{
				remainingTeams.Remove(team);
				foreach (var otherTeam in remainingTeams)
				{
					matches.Add(new(team, otherTeam));
				}
			}

			return matches;
		}
	}
}
