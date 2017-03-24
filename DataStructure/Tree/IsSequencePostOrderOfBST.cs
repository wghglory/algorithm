using System;
using System.Collections.Generic;

/*http://codercareer.blogspot.com/2011/09/no-06-post-order-traversal-sequences-of.html

given a sequence, can it be post order of a BST?

*/
public class IsSequencePostOrderOfBST
{

	bool VerifySquenceOfBST(int[] sequence, int length)
	{
		if (sequence == null || length <= 0)
			return false;

		int root = sequence[length - 1];

		// nodes in left sub-tree are less than root node
		int i = 0;
		for (; i < length - 1; ++i)
		{
			if (sequence[i] > root)
				break;
		}

		// nodes in right sub-tree are greater than root node
		int j = i;
		for (; j < length - 1; ++j)
		{
			if (sequence[j] < root)
				return false;
		}

		// Is left sub-tree a binary search tree?
		bool left = true;
		if (i > 0)
			left = VerifySquenceOfBST(sequence, i);

		// Is right sub-tree a binary search tree?
		bool right = true;
		if (i < length - 1)
			right = VerifySquenceOfBST(sequence, length - i - 1);

		return (left && right);
	}

	public static void Main(string[] args)
	{
		IsSequencePostOrderOfBST h = new IsSequencePostOrderOfBST();
		Console.WriteLine(h.VerifySquenceOfBST(new int[] { 5, 7, 6, 9, 11, 10, 8 }, 7));
		Console.WriteLine(h.VerifySquenceOfBST(new int[] { 79, 7, 6, 9, 11, 10, 8 }, 7));
	}

	private static Node DefineBST()
	{

		//          5
		//        /   \
		//       2     10
		//      / \    / \
		//     1   3   7  12
		//             /\
		//            6  8


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
		node.Right.Left.Right.Data = 8;

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
