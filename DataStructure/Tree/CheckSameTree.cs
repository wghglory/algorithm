using System;
/**
* Date 04/11/2015
* @author tusroy
*
* Youtube link - https://youtu.be/ySDDslG8wws
*
* Given roots of two tree, return true if they have same data and same structure
* or return false.
*
* Solution
* Keep comparing root of both data and then recursively check left and right.
*
* Time complexity is O(n)
*/
public class SameTree
{
	public static void Main(string[] args)
	{
		BinarySearchTree bt = new BinarySearchTree();
		Node root1 = null;
		root1 = bt.AddNode(10, root1);
		root1 = bt.AddNode(20, root1);
		root1 = bt.AddNode(15, root1);
		root1 = bt.AddNode(2, root1);

		Node root2 = null;
		root2 = bt.AddNode(10, root2);
		root2 = bt.AddNode(20, root2);
		root2 = bt.AddNode(2, root2);
		root2 = bt.AddNode(15, root2);

		Console.WriteLine(bt.SameTree(root1, root2));
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Left { get; set; }
	public Node Right { get; set; }

	public Node(int data)
	{
		Data = data;
		Left = null;
		Right = null;
	}
}

public class BinarySearchTree
{
	public Node AddNode(int data, Node node)
	{
		Node root = node;
		if (node == null)
			return new Node(data);

		Node leaf = null;
		while (node != null)
		{
			leaf = node;
			if (data > node.Data)
			{
				node = node.Right;
			}
			else
			{
				node = node.Left;
			}
		}

		if (data > leaf.Data)
		{
			leaf.Right = new Node(data);
		}
		else
		{
			leaf.Left = new Node(data);
		}
		return root;
	}

	public bool SameTree(Node root1, Node root2)
	{
		if (root1 == null && root2 == null)
		{
			return true;
		}
		if (root1 == null || root2 == null)
		{
			return false;
		}

		return root1.Data == root2.Data &&
				SameTree(root1.Left, root2.Left) &&
				SameTree(root1.Right, root2.Right);
	}
}
