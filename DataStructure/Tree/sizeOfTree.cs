/**
 * Date 03/05/2015
 * @author tusroy
 * https://www.youtube.com/watch?v=NA8B84DZYSA&list=PLrmLmBdmIlpv_jNDXtJGYTPNQ2L1gdHxu&index=5
 * Given a root of binary tree, return size of binar tree
 *
 * Solution:
 * Recursively find size of left side, right side and add one to them and return that to calling function.
 *
 * Time complexity - O(n)
 * Space complexity(because of recursion stack) - height of binary tree. Worst case O(n)
 *
 * Test cases:
 * Null tree
 * 1 node tree
 * multi node tree
 */

using System;

public class SizeOfBinaryTree
{
	// how many count of node?
	public int size(Node root)
	{
		if (root == null)
		{
			return 0;
		}
		return size(root.Left) + size(root.Right) + 1;
	}

	public static void Main(string[] args)
	{
		BinaryTree bt = new BinaryTree();
		Node root = null;
		root = bt.addNode(10, root);
		root = bt.addNode(15, root);
		root = bt.addNode(5, root);
		root = bt.addNode(7, root);
		root = bt.addNode(19, root);
		root = bt.addNode(20, root);
		root = bt.addNode(-1, root);

		SizeOfBinaryTree sbt = new SizeOfBinaryTree();
		Console.WriteLine(sbt.size(root));
	}
}

public class BinaryTree
{
	public Node head;

	public Node addNode(int data, Node node)
	{
		if (node == null) return new Node(data);

		Node root = node;
		Node leaf = null;

		while (node != null)
		{
			leaf = node;
			if (data < node.Data) node = node.Left;
			else node = node.Right;
		}

		if (data < leaf.Data) leaf.Left = new Node(data);
		else leaf.Right = new Node(data);

		return root;
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
		Right = null;
		Left = null;
	}
}
