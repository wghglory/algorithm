using System;

// can be used for normal Binary tree in DFS way
public class BST
{
	public static void Main(string[] args)
	{
		BST bst = new BST();
		bst.CreateBST();

		bst.BSTDisplay(bst.root, 0);

		Console.Write("\nInOrder Traversal : ");
		bst.inOrder(bst.root);

		//Node ddlHeadNode = null;
		//ddlHeadNode = bst.BinaryTree2DoublyLinkedList(bst.root, ddlHeadNode);
		//if (ddlHeadNode != null)
		//{
		//	Console.Write("\nFrom start : ");
		//	while (ddlHeadNode.Right != null)
		//	{
		//		Console.Write(ddlHeadNode.Data + " ");
		//		ddlHeadNode = ddlHeadNode.Right;
		//	}
		//	Console.Write(ddlHeadNode.Data + " ");

		//	Console.Write("\nFrom end : ");

		//	while (ddlHeadNode.Left != null)
		//	{
		//		Console.Write(ddlHeadNode.Data + " ");
		//		ddlHeadNode = ddlHeadNode.Left;
		//	}
		//	Console.Write(ddlHeadNode.Data + " ");
		//}


		Node node = bst.ToLinkedList(bst.root);

		if (node != null)
		{
			Console.Write("\nFrom start : ");
			while (node.Right != null)
			{
				Console.Write(node.Data + " ");
				node = node.Right;
			}
			Console.Write(node.Data + " ");

			Console.Write("\nFrom end : ");

			while (node.Left != null)
			{
				Console.Write(node.Data + " ");
				node = node.Left;
			}
			Console.Write(node.Data + " ");
		}
	}

	public class Node
	{
		public Node(string v)
		{
			Data = v;
		}
		public string Data;
		public Node Left;
		public Node Right;

	}

	private Node root;

	public void CreateBST()
	{
		root = new Node("10");
		root.Left = new Node("6");
		root.Right = new Node("14");

		root.Left.Left = new Node("4");
		root.Left.Left.Left = new Node("2");
		root.Left.Left.Right = new Node("5");
		root.Left.Right = new Node("8");

		root.Right.Left = new Node("12");
		root.Right.Right = new Node("16");
	}


	public void BSTDisplay(Node node, int numberOfSpace)
	{
		if (node != null)
		{
			BSTDisplay(node.Right, ++numberOfSpace);
			for (int i = 0; i < numberOfSpace; i++)
			{
				Console.Write(" ");
			}
			Console.Write(node.Data + "\n\n");

			BSTDisplay(node.Left, numberOfSpace);
		}
	}


	public void inOrder(Node node)
	{
		if (node != null)
		{
			inOrder(node.Left);
			Console.Write(node.Data + " ");
			inOrder(node.Right);
		}
	}

	public Node GetRightMostLeaf(Node node)
	{
		if (node != null)
			while (node.Right != null) node = node.Right;
		return (node);
	}

	public Node GetLeftMostLeaf(Node node)
	{
		if (node != null)
			while (node.Left != null) node = node.Left;
		return (node);
	}


	/*-----------------------DFS method 1-------------------------*/
	public Node BinaryTree2DoublyLinkedList(Node node, Node listHead)  //node is binarytree node, listHead is ddl headnode
	{
		if (node != null)
		{
			if (node.Left != null)
			{
				listHead = BinaryTree2DoublyLinkedList(node.Left, listHead);
				Node getRightMostLeaf = GetRightMostLeaf(node.Left);
				getRightMostLeaf.Right = node;
				node.Left = getRightMostLeaf;
				if (listHead == null)
				{
					listHead = node.Left;
				}
			}

			if (node.Right != null)
			{
				listHead = BinaryTree2DoublyLinkedList(node.Right, listHead);
				Node getLeftMostLeaf = GetLeftMostLeaf(node.Right);

				node.Right = getLeftMostLeaf;
				getLeftMostLeaf.Left = node;
			}
		}
		return listHead;
	}


	/*-----------------------DFS: method 2 seems easier than above-----------------------------*/
	public Node ToLinkedList(Node node)
	{
		if (node == null) return null;
		node = ConvertToLinkedList(node);

		// find linked list head
		while (node.Left != null)
		{
			node = node.Left;
		}

		return node;
	}

	private Node ConvertToLinkedList(Node node)
	{
		if (node == null) return null;

		if (node.Left != null)
		{
			var left = ConvertToLinkedList(node.Left);
			// find rightmost for left node
			while (left.Right != null) left = left.Right;

			left.Right = node;  // rightmost right points to root
			node.Left = left;   // root left points to the left rightmost
		}

		if (node.Right != null)
		{
			var right = ConvertToLinkedList(node.Right);

			// find leftmost for right node
			while (right.Left != null) right = right.Left;

			right.Left = node;  // left rightmost left points to root
			node.Right = right;  // root right points to rightmost
		}

		return node;
	}
}
