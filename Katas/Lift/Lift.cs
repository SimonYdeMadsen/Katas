using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Lift
{
	public class Lift
	{
		private enum Direction { Up, Down }

		private readonly int capacity;
		private readonly int highestFloor;
		private Direction currentDirection = Direction.Up;

		public int HighestFloor { get { return highestFloor; } }

		public int CurrentFloor { get; private set; } = 0;

		public int PeopleInside { get { return people.Count; } }

		public int RemainingCapacity { get { return capacity - PeopleInside; } }

		public bool UpIsCleared { get; set; } = false;
		public bool DownIsCleared { get; set; } = false;

		private List<int> people = new List<int>();

		public Lift(int capacity, int highestFloor)
		{
			this.capacity = capacity;
			this.highestFloor = highestFloor;
		}

		public bool IsEmpty()
		{
			return people.Count == 0;
		}

		public bool IsFull()
		{
			return people.Count >= capacity;
		}

		public bool IsAtMaxFloor()
		{
			return CurrentFloor == highestFloor;
		}

		public bool IsAtMinFloor()
		{
			return CurrentFloor == 0;
		}

		public bool IsGoingUp()
		{
			return currentDirection == Direction.Up;
		}
		

		public void AddPerson(int person)
		{
			if (!this.IsFull())
			{
				people.Add(person);
			}
			else
			{
				throw new NotImplementedException();
			}
		}

		public void RemovePerson(int person)
		{
			people.Remove(person);
		}
	
		public void Move()
		{
			if (currentDirection == Direction.Up)
			{
				CurrentFloor++;
			}
			else
			{
				CurrentFloor--;
			}

			if ((this.IsAtMaxFloor() || this.IsAtMinFloor()))
			{
				this.ChangeDirection();
			}
		}


		public List<int> GetExitingPeople()
		{
			return people.Where(id => id == CurrentFloor).ToList();
		}

		public void ChangeDirection()
		{
			currentDirection = ~currentDirection;
			Console.WriteLine($"Direction now {currentDirection}");
		}

		public string GetPeopleString()
		{
			return '['+string.Join(", ", people)+']';
		}



	}
}
