//https://www.youtube.com/watch?v=Jg4E4KZstFE

using System;
using System.Collections.Generic;

/**
 * Date 04/11/2015
 * @author tusroy
 *
 * Youtube link - https://youtu.be/Jg4E4KZstFE
 *
 * Given a binary tree and a sum, find if there is a path from root to leaf
 * which sums to this sum.
 *
 * Solution
 * Keep going left and right and keep subtracting node value from sum.
 * If leaf node is reached check if whatever sum is remaining same as leaf node data.
 *
 * Time complexity is O(n) since all nodes are visited.
 *
 * Test cases:
 * Negative number, 0 and positive number
 * Tree with 0, 1 or more nodes
 *
 * Reference http://www.geeksforgeeks.org/root-to-leaf-path-sum-equal-to-a-given-number/
 */
public class RootToLeafToSum
{

	public bool printPath(Node root, int sum, List<Node> path)
	{
		if (root == null)
		{
			return false;
		}

		if (root.Left == null && root.Right == null)   //leaf
		{
			if (root.Data == sum)
			{
				path.Add(root);
				return true;
			}
			else
			{
				return false;
			}
		}
		if (printPath(root.Left, sum - root.Data, path) || printPath(root.Right, sum - root.Data, path))
		{
			path.Add(root);
			return true;
		}
		return false;
	}

	public static void Main(string[] args)
	{
		RootToLeafToSum rtl = new RootToLeafToSum();

		//          5
		//        /   \
		//       2     10
		//      / \    / \
		//     27   3   7  12
		//             /\
		//            6  7

		// sum = 29, 2 paths: 5-2-27, 5-10-7-7, but this solution only finds the first path
		// if needs to find all paths, see FindPathsFromRootToLeaf.cs and check all paths' sum

		Node node = new Node();
		node.Data = 5;
		node.Right = new Node();
		node.Left = new Node();

		node.Left.Data = 2;
		node.Right.Data = 10;

		node.Left.Left = new Node();
		node.Left.Right = new Node();
		node.Left.Left.Data = 22;
		node.Left.Right.Data = 3;

		node.Right.Left = new Node();
		node.Right.Right = new Node();
		node.Right.Left.Data = 7;
		node.Right.Right.Data = 12;

		node.Right.Left.Left = new Node();
		node.Right.Left.Right = new Node();
		node.Right.Left.Left.Data = 6;
		node.Right.Left.Right.Data = 7;


		List<Node> result = new List<Node>();
		bool r = rtl.printPath(node, 29, result);
		if (r)
		{
			result.ForEach(x => Console.Write(x.Data + " "));
		}
		else
		{
			Console.Write("No path for sum " + 29);
		}
	}
}

public class Node
{
	public Node Left { get; set; }
	public Node Right { get; set; }
	public int Data { get; set; }
}
