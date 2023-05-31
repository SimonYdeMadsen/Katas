using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas.Lift;
using System.Collections.Generic;

namespace KataTests
{
	[TestClass]
	public class LiftTests
	{
		

		[TestMethod]
		public void DefaultTestWithPlentyCapacity()
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

			var result = Dinglemouse.TheLift(queues, 5);

			var truth = new[] { 0, 2, 5, 0 };
			Assert.IsTrue(result.SequenceEqual(truth));
		}

		[TestMethod]
		public void DefaultTestWithLimitedCapacity()
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

			var result = Dinglemouse.TheLift(queues, 2);

			var truth = new[] { 0, 2, 5, 2, 5, 0 };
			Assert.IsTrue(result.SequenceEqual(truth));
		}


	}
}