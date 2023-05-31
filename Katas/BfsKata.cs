using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class BfsKata
{
	public static int SumTreeBFS(Node root)
	{
		var sum = 0;

		var queue = new Queue<Node>();
		var exploredNodes = new List<Node>();

		queue.Enqueue(root);
		while (queue.Count > 0)
		{
			Console.WriteLine($"queue.Count: {queue.Count}");
			var node = queue.Dequeue();
			sum += node.Value;
			Console.WriteLine($"sum: {sum}");
			var children = new List<Node>();
			if (node.Left != null) { children.Add(node.Left); }
			if (node.Right != null) { children.Add(node.Right); }
			foreach (var child in children)
			{
				if (!exploredNodes.Contains(child))
				{
					exploredNodes.Add(child);
					queue.Enqueue(child);
				}
			}
		}
		return sum;
	}


	public static int SumTreeDFS(Node root)
	{
		var sum = 0;

		var exploredNodes = new List<Node>();
		var stack = new Stack<Node>();

		stack.Push(root);
		Console.WriteLine(string.Join(", ", stack));
		while (stack.Count > 0)
		{
			var node = stack.Pop();
			sum += node.Value;
			var children = new List<Node>();
			if (node.Left != null) { children.Add(node.Left); }
			if (node.Right != null) { children.Add(node.Right); }
			if (!exploredNodes.Contains(node))
			{
				exploredNodes.Add(node);
				foreach (var child in children)
				{
					stack.Push(child);
					
				}
				Console.WriteLine(string.Join(", ", stack));
			}

		}

		return sum;
	}


}