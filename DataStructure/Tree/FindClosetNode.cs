using System;

/**
get closest node for target in BST
*/
public class IsBST
{
	public static Node getClosestNode(Node node, int target)
	{
		Node pClosest = null;
		int minDistance = int.MaxValue;

		while (node != null)
		{
			int distance = Math.Abs(node.Data - target);
			if (distance < minDistance)
			{
				minDistance = distance;
				pClosest = node;
			}

			if (distance == 0)
				break;

			if (node.Data > target)
				node = node.Left;
			else if (node.Data < target)
				node = node.Right;
		}

		return pClosest;
	}

	public static void Main(string[] args)
	{
		Node root = DefineBST();

		Console.WriteLine(getClosestNode(root, 11).Data);
	}

	private static Node DefineBST()
	{

		//          5
		//        /   \
		//       2     10
		//      / \    / \
		//     1   3   7  12
		//             /\
		//            6  7

		Node node = new Node();
		node.Data = 5;
		node.Right = new Node();
		node.Left = new Node();

		node.Left.Data = 2;
		node.Right.Data = 10;

		node.Left.Left = new Node();
		node.Left.Right = new Node();
		node.Left.Left.Data = 1;
		node.Left.Right.Data = 3;

		node.Right.Left = new Node();
		node.Right.Right = new Node();
		node.Right.Left.Data = 7;
		node.Right.Right.Data = 12;

		node.Right.Left.Left = new Node();
		node.Right.Left.Right = new Node();
		node.Right.Left.Left.Data = 6;
		node.Right.Left.Right.Data = 7;  //7, 8

		return node;
	}
}


public class Node
{
	public int Data;
	public Node Left;
	public Node Right;

	public Node(int Data, Node Left, Node Right)
	{
		this.Data = Data;
		this.Left = Left;
		this.Right = Right;
	}

	public Node(int Data)
	{
		this.Data = Data;
		this.Left = null;
		this.Right = null;
	}

	public Node() { }
}
