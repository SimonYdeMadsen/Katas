using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Lift
{
	public class Dinglemouse
	{
		


		public static int[] TheLift(int[][] queues, int capacity)
		{
			var floors = queues.Select(arr => arr.ToList()).ToList();

			PrettyPrintQueues(floors);

			

			int highestFloor = queues.Length - 1;
			var lift = new Lift(capacity, highestFloor);
			var result = new List<int>() { 0 };

			
			// 1 v 0
			while (!IsEmpty(floors) || !lift.IsEmpty())
			{
				Console.WriteLine($"Floor now: {lift.CurrentFloor}");

				bool shouldUpdateResult = false;
				List<int> floor = floors[lift.CurrentFloor];
				if (PeopleWaiting(floor))
				{
					shouldUpdateResult = true;
					var newPeople = new List<int>();
					if (!lift.IsFull())
					{

						if (lift.IsGoingUp())
						{
							newPeople = floor
								.Where(n => n > lift.CurrentFloor)
								.Take(lift.RemainingCapacity)
								.ToList();
						}
						else
						{
							newPeople = floor
								.Where(n => n < lift.CurrentFloor)
								.Take(lift.RemainingCapacity)
								.ToList();
						}

						newPeople.ForEach(person => lift.AddPerson(person));
						newPeople.ForEach(person => floor.Remove(person));
					}
				}

				var outPeople = lift.GetExitingPeople();
				if (PeopleWantOut(outPeople))
				{
					Console.WriteLine($"outPeople: [{string.Join(",", outPeople)}]");
					shouldUpdateResult = true;
					outPeople.ForEach(person => lift.RemovePerson(person));
				}

				if (ShouldBeSmart(lift) && (lift.IsGoingUp() && !lift.UpIsCleared) )
				{
					Console.Write("Should be smart: ");

					//Don't go to floor 6 (if lift empty) and there are no people there.
					//Don't go to floor 1 (if lift empty) and there are no people there.
					if (floors.Skip(lift.CurrentFloor).Take(lift.HighestFloor - lift.CurrentFloor).All(floor => floor.Count == 0))
					{
						lift.UpIsCleared = true;
					}
					else
					{
						Console.WriteLine("Up isn't cleared.");
					}
					if (lift.UpIsCleared)
					{
						Console.WriteLine("All floors above have been cleared.");
						lift.ChangeDirection();
					}
				}
				else if (ShouldBeSmart(lift) && (!lift.IsGoingUp() && !lift.DownIsCleared))
				{
					Console.Write("Should be smart. ");

					if (floors.Take(lift.CurrentFloor).All(floor => floor.Count == 0))
					{
						lift.DownIsCleared = true;
					}
					else
					{
						Console.WriteLine("Down isn't cleared.");
					}

					if (lift.DownIsCleared)
					{
						Console.WriteLine("All floors above have been cleared.");
						lift.ChangeDirection();
					}
					else if (lift.DownIsCleared)
					{
						Console.WriteLine("Down is cleared but lift not empty.");
					}
					
				}

				Console.WriteLine($"Lift status: {lift.GetPeopleString()}");
				if (shouldUpdateResult)
				{
					result.Add(lift.CurrentFloor);
				}
				lift.Move(); // Move now has the direction change. 
				Console.ReadLine();
			}

			result.Add(0);
			Console.WriteLine($"Result: {string.Join(", ", result)}");
			return result.ToArray();
		}

		private static bool ShouldBeSmart(Lift lift)
		{
			return lift.IsEmpty() && !lift.IsAtMinFloor() && !lift.IsAtMaxFloor();
		}

		private static bool IsEmpty(List<int> lift)
		{
			return lift.Count == 0;
		}

		private static bool PeopleWantOut(List<int> outPeople)
		{
			return outPeople.Count > 0;
		}


		private static bool IsEmpty(List<List<int>> queues)
		{
			return queues.All(list => list.Count == 0);
		}

		private static bool PeopleWaiting(List<int> queue)
		{
			return queue.Count > 0;
		}

		public static void PrettyPrintQueues(List<List<int>> queues)
		{
			string liftString = "|=================|\n";
			for (int i = 0; i < queues.Count; i++)
			{
				liftString = ($"{i}|{Pretty(queues[i])}\n") + liftString;
				
			}
			Console.WriteLine(liftString);
		}

		public static string Pretty(List<int> queue)
		{
			var people = string.Join(",", queue);
			var result = "----------------|";
			result = result.Substring(people.Length);
			return people + result;
		}

	}
}
