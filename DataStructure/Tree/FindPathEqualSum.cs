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

	public bool printPath(Node node, int sum, List<Node> path)   //sum is number passed to next childnode
	{
		if (node == null)
		{
			return false;
		}

		if (node.Left == null && node.Right == null && node.Data == sum)   //leaf
		{
			path.Add(node);
			return true;
		}
		if (printPath(node.Left, sum - node.Data, path) || printPath(node.Right, sum - node.Data, path))
		{
			path.Add(node);
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
		//     22   3   7  12
		//             /\
		//            6  7

		// sum = 29, 2 paths: 5-2-22, 5-10-7-7, but this solution only finds the first path
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

		Console.WriteLine(haspathSum(node, 10));
		Console.WriteLine(hasPathSum(node, 10));
	}


	/*
     Given a tree and a sum, return true if there is a path from the root
     down to a leaf, such that adding up all the values along the path
     equals the given sum.

     Strategy: subtract the node value from the sum when recurring down,
     and check to see if the sum is 0 when you run out of tree.
     */

	static bool haspathSum(Node node, int sum)
	{
		if (node == null)
			return false;

		bool result = false;

		/* otherwise check both subtrees */
		//int subsum = sum - node.Data;
		//if (subsum == 0 && node.Left == null && node.Right == null)
		//	return true;
		//if (node.Left != null)
		//	result = result || haspathSum(node.Left, subsum);
		//if (node.Right != null)
		//	result = result || haspathSum(node.Right, subsum);

		if (sum == node.Data && node.Left == null && node.Right == null)
			return true;
		if (node.Left != null)
			result = result || haspathSum(node.Left, sum - node.Data);
		if (node.Right != null)
			result = result || haspathSum(node.Right, sum - node.Data);
		return result;
	}

	public static bool hasPathSum(Node node, int sum)
	{
		if (node == null) return false;

		Queue<Node> nodes = new Queue<Node>();
		Queue<int> values = new Queue<int>();

		nodes.Enqueue(node);
		values.Enqueue(node.Data);

		while (nodes.Count > 0)
		{
			Node curr = nodes.Dequeue();
			int sumValue = values.Dequeue();

			if (curr.Left == null && curr.Right == null && sumValue == sum)
			{
				return true;
			}

			if (curr.Left != null)
			{
				nodes.Enqueue(curr.Left);
				values.Enqueue(sumValue + curr.Left.Data);
			}

			if (curr.Right != null)
			{
				nodes.Enqueue(curr.Right);
				values.Enqueue(sumValue + curr.Right.Data);
			}
		}

		return false;
	}

}

public class Node
{
	public Node Left { get; set; }
	public Node Right { get; set; }
	public int Data { get; set; }
}
