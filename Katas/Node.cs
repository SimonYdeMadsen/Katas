public class Node
{
	public int Value;
	public Node Left;
	public Node Right;

	public Node(int value, Node left, Node right)
	{
		Value = value;
		Left = left;
		Right = right;
	}

	public override string ToString()
	{
		return $"Node({Left}, {Right})={Value}";
	}
}