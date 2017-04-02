using System;

/*
 *
PreOrder:
      1
     / \
    2   5
   /\   /\
  3  4 6  7
 / \  \
9  10 12

 1 <==> 2 <==> 3 <==> 9 <==> 10 <==> 4 <==> 12 <==> 5 <==> 6 <==>7

create a DLL node based on tree parent node for each recursive call,
traverse left, then right
link left node to parent node
link right node to DLL tail node


InOrder:
      7
     / \
    4   9
   /\   /\
  2  5  8 10
 / \  \
1   3  6
 1 <==> 2 <==> 3 <==> 4 <==> 5 <==> 6 <==> 7 <==> 8 <==> 9 <==> 10
*/
public class Convert
{
	/// <summary>
	/// convert binary tree to DLL. Recursively call and create a DLL node
	/// </summary>
	/// <param name="node">binary tree node</param>
	/// <returns>dll Node</returns>
	private static Node ConvertBT2DLL_PreOrder(Node node)
	{
		if (node == null) return null;

		//create a DLL based on tree parent node
		Node dllNode = new Node(node.Data);

		if (node.Left != null)
		{
			// create a DLL node based on tree left node
			Node leftNode = ConvertBT2DLL_PreOrder(node.Left);
			// link leftNode to dllNode, dllNode is 1, leftNode is 2, 1 <==> 2
			leftNode.Left = dllNode;
			dllNode.Right = leftNode;
		}

		// // This works as well: create a DLL node based on tree left node
		// Node leftNode = ConvertBT2DLL_PreOrder(node.Left);
		// if (leftNode != null)
		// {
		// 	// link leftNode to dllNode, dllNode is 1, leftNode is 2, 1 <==> 2
		// 	leftNode.Left = dllNode;
		// 	dllNode.Right = leftNode;
		// }

		if (node.Right != null)
		{
			// linked rightNode to tailNode, tailNode is 2, rightNode is 3, 1 <==> 2 <==> 3
			Node rightNode = ConvertBT2DLL_PreOrder(node.Right);
			Node tailNode = FindDLLTailNode(dllNode);
			rightNode.Left = tailNode;
			tailNode.Right = rightNode;
		}

		return dllNode;
	}


	// find tail node given DLL firstnode
	private static Node FindDLLTailNode(Node node)
	{
		while (node.Right != null)
		{
			node = node.Right;
		}
		return node;
	}

	private static Node ConvertBT2DLL_InOrder(Node node)
	{
		Node root = ConvertBT2DLL_inOrder(node);

		// move pointer to first node in dll
		while (root.Left != null)
			root = root.Left;

		return root;
	}

	// modify binary tree to doubly linked list, no dll node created
	private static Node ConvertBT2DLL_inOrder(Node node)
	{
		if (node == null) return null;

		if (node.Left != null)
		{
			Node leftNode = ConvertBT2DLL_inOrder(node.Left);

			// get rightmost node for left side, this node should link with its grandpa(node)
			while (leftNode.Right != null) leftNode = leftNode.Right;

			leftNode.Right = node;
			node.Left = leftNode;
		}

		if (node.Right != null)
		{
			Node rightNode = ConvertBT2DLL_inOrder(node.Right);

			// get leftmost node
			while (rightNode.Left != null) rightNode = rightNode.Left;

			rightNode.Left = node;
			node.Right = rightNode;
		}

		return node;  //return the root of binary tree, should be middle if BST.
	}

	public static void Main(string[] args)
	{
		Node root1 = BuildTree1();
		//PreOrder(root1);
		Node dllNode = ConvertBT2DLL_PreOrder(root1);
		PrintDLL(dllNode);

		Console.WriteLine("\nbelow is inorder");

		Node root2 = BuildBST();
		root2 = ConvertBT2DLL_InOrder(root2);
		PrintDLL(root2);
	}

	private static Node BuildTree1()
	{
		Node root = new Node(1);
		root.Left = new Node(2);
		root.Right = new Node(5);

		root.Left.Left = new Node(3);
		root.Left.Right = new Node(4);

		root.Right.Left = new Node(6);
		root.Right.Right = new Node(7);

		root.Left.Left.Left = new Node(9);
		root.Left.Left.Right = new Node(10);
		root.Left.Right.Right = new Node(12);

		return root;
	}

	private static Node BuildBST()
	{
		Node root = new Node(7);
		root.Left = new Node(4);
		root.Right = new Node(9);

		root.Left.Left = new Node(2);
		root.Left.Right = new Node(5);

		root.Right.Left = new Node(8);
		root.Right.Right = new Node(10);

		root.Left.Left.Left = new Node(1);
		root.Left.Left.Right = new Node(3);
		root.Left.Right.Right = new Node(6);

		return root;
	}

	private static void PrintDLL(Node node)
	{
		if (node == null) return;

		Console.WriteLine("\nleft to right");

		while (node.Right != null)
		{
			Console.Write(node.Data + " ");
			node = node.Right;
		}
		Console.Write(node.Data + " \n");

		Console.WriteLine("\nright to left");

		while (node.Left != null)
		{
			Console.Write(node.Data + " ");
			node = node.Left;
		}
		Console.Write(node.Data + " \n");
	}

	private static void InOrder(Node root)
	{
		if (root == null) return;

		InOrder(root.Left);
		Console.Write(root.Data + " ");
		InOrder(root.Right);
	}

	private static void PreOrder(Node root)
	{
		if (root == null) return;

		Console.Write(root.Data + " ");
		PreOrder(root.Left);
		PreOrder(root.Right);
	}
}

public class Node
{
	// this node is used for both tree and doubly linked list
	public int Data { get; set; }

	public Node Left { get; set; }
	public Node Right { get; set; }

	public Node(int data)
	{
		Data = data;
	}
}
