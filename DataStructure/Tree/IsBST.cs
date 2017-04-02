using System;
using System.Collections.Generic;
/**
* Date 04/11/2015
* @author tusroy
*
* Youtube link - https://youtu.be/MILxfAbIhrE
*
* Given a binary tree, return true if it is binary search tree else return false.
*
* Solution
* Keep min, max for every recursion. Initial min and max is very small and very larger
* number. Check if root.Data is in this range. When you go Left pass min and root.Data and
* for Right pass root.Data and max.
*
* Time complexity is O(n) since we are looking at all nodes.
*
* Test cases:
* Null tree
* 1 or 2 nodes tree
* Binary tree which is actually BST
* Binary tree which is not a BST
*/
public class IsBST
{

	public bool isBST(Node root)
	{
		return isBST1(root, int.MinValue, int.MaxValue);
	}

	//every node: left < parent < right,
	// min < left < parent
	// parent < right < max
	private bool isBST1(Node node, int min, int max)
	{
		if (node == null)
		{
			return true;
		}
		if (node.Data < min || node.Data > max)
		{
			return false;
		}
		return isBST1(node.Left, min, node.Data) && isBST1(node.Right, node.Data, max);
	}


	public bool isBST2(Node node)
	{
		if (root == null) return true;

        Stack<Node> s = new Stack<Node>();

        while (root != null)
        {
            s.Push(root);
            root = root.Left;
        }

        int prev = int.MinValue;
        while (s.Count > 0)
        {
            Node current = s.Pop();

            Console.WriteLine($"prevData: {prev}, currentData: {current.Data}");

            if (prev > current.Data)
            {
                return false;
            }

            Node rightOfCurrent = current.Right;

            while (rightOfCurrent != null)
            {
                s.Push(rightOfCurrent);
                rightOfCurrent = rightOfCurrent.Left;
            }

            prev = current.Data;
        }

        return true;
	}


	public static void Main(string[] args)
	{
		Node root = DefineBST();

		IsBST isBST = new IsBST();

		Console.WriteLine(isBST.isBST(root));
		Console.WriteLine(isBST.isBST2(root));
		Console.WriteLine(isBST.isBST3(root, int.MinValue));
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
