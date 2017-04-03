
using System;
/**
* Date 04/11/2015
* @author tusroy
*
* Youtube link - https://youtu.be/zm83jPHZ-jA
*
* Given a binary search tree and a key, return node which has data as this key or return
* null if no node has data as key.
*
* Solution
* Since its BST for every node check if root.data is key and if not go either left or
* right depending on if root.data is greater or less than key
*
* Time complexity is O(n) for non balanced BST
* Time complexity is O(logn) for balanced BST
*
* Test cases:
* 1) null tree
* 2) Tree with one node and key is that node
* 3) Tree with many nodes and key does not exist
* 4) Tree with many nodes and key exists
*/
public class BSTSearch
{

	public Node search(Node root, int key)
	{
		if (root == null) return null;

		if (root.data == key) return root;
		else if (root.data < key) return search(root.right, key);
		else return search(root.left, key);
	}

	public static void Main(string[] args)
	{
		BSTSearch bt = new BSTSearch();
		Node root = null;
		root = bt.AddNode(10, root);
		root = bt.AddNode(20, root);
		root = bt.AddNode(-10, root);
		root = bt.AddNode(15, root);
		root = bt.AddNode(0, root);
		root = bt.AddNode(21, root);
		root = bt.AddNode(-1, root);

		BSTSearch bstSearch = new BSTSearch();
		Node result = bstSearch.search(root, 21);
		Console.WriteLine(result.data == 21);

		result = bstSearch.search(root, -1);
		Console.WriteLine(result.data == 21);

		result = bstSearch.search(root, 11);
		Console.WriteLine(result == null);
	}

	public Node AddNode(int data, Node node)
	{
		Node root = node;
		if (node == null) return new Node(data);

		Node leaf = null;
		while (node != null)
		{
			leaf = node;
			if (data > leaf.data)
			{
				node = node.right;
			}
			else { node = node.left; }
		}

		if (data > leaf.data) leaf.right = new Node(data);
		else leaf.left = new Node(data);

		return root;
	}
}

public class Node
{
	public int data { get; set; }
	public Node left { get; set; }
	public Node right { get; set; }

	public Node(int d)
	{
		data = d;
		left = null;
		right = null;
	}
}
