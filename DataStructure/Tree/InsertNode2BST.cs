using System;
/**
* Date 07/07/2014
* @author tusroy
*
* Youtube link - https://youtu.be/bmaeYtlO2OE
* Youtube link - https://youtu.be/_SiwrPXG9-g
* Youtube link - https://youtu.be/NA8B84DZYSA
*
*/

public class Node
{
	public Node left;
	public Node right;
	public int data;

	public static Node newNode(int data)
	{
		Node n = new Node();
		n.left = null;
		n.right = null;
		n.data = data;
		return n;
	}
}

public class BinarySearchTree
{
	public Node addNode(int data, Node node)
	{
		Node root = node;
		Node n = Node.newNode(data);
		if (node == null)
		{
			node = n;
			return node;
		}

		Node prev = null;  //the leaf that will add new node
		while (node != null)
		{
			prev = node;
			if (node.data < data)
			{
				node = node.right;
			}
			else
			{
				node = node.left;
			}
		}

		//add new data to left or right leaf
		if (prev.data < data)
		{
			prev.right = n;
		}
		else
		{
			prev.left = n;
		}
		return root;  //not the new added node
	}

	public int height(Node root)
	{
		if (root == null)
		{
			return 0;
		}
		int leftHeight = height(root.left);
		int rightHeight = height(root.right);
		return Math.Max(leftHeight, rightHeight) + 1;
	}

	public static void Main(string[] args)
	{
		BinarySearchTree bt = new BinarySearchTree();
		Node root = null;
		root = bt.addNode(10, root);
		root = bt.addNode(15, root);
		root = bt.addNode(5, root);
		root = bt.addNode(7, root);
		root = bt.addNode(19, root);
		root = bt.addNode(20, root);
		root = bt.addNode(-1, root);
		root = bt.addNode(21, root);
		Console.WriteLine(bt.height(root));

	}
}
