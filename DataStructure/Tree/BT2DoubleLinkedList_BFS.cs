using System;
using System.Collections.Generic;

class Program
{

	static void Main(string[] args)
	{

		Convert binaryTreeToList = new Convert();
		//            0
		//        2         4
		//     6    8          10
		TreeNode root = new TreeNode(0);
		root.Left = new TreeNode(2);
		root.Right = new TreeNode(4);
		root.Left.Left = new TreeNode(6);
		root.Left.Right = new TreeNode(8);
		root.Right.Right = new TreeNode(10);

		var node = binaryTreeToList.ToDoubleLinkedListNode(root);

		if (node != null)
		{
			Console.Write("\nFrom start : ");
			while (node.Next != null)
			{
				Console.Write(node.Data + " ");
				node = node.Next;
			}
			Console.Write(node.Data + " ");

			Console.Write("\nFrom end : ");

			while (node.Previous != null)
			{
				Console.Write(node.Data + " ");
				node = node.Previous;
			}
			Console.Write(node.Data + " ");
		}


		Console.ReadKey();
	}


}


public class Convert
{

	// BFS
	public DoublyLinkedListNode ToDoubleLinkedListNode(TreeNode root)
	{
		if (root == null) { return null; }

		DoublyLinkedListNode convertedNode = new DoublyLinkedListNode { Data = root.Data };

		if (root.Left != null)
		{
			var leftNode = ToDoubleLinkedListNode(root.Left);
			leftNode.Previous = convertedNode; // take 0 and 2 for instance, 0 is convertedNode, leftNode is 2
			convertedNode.Next = leftNode;
		}

		if (root.Right != null)
		{
			var rightNode = ToDoubleLinkedListNode(root.Right);

			// take 2 and 4 for instance, now 0 and 2 are linked to each other, [0, 2] 2 is last node in ddl,
			// we want to find tail node in ddl and build pointers to rightNode

			DoublyLinkedListNode tailNode = FIndTailNodeInDLL(convertedNode);
			rightNode.Previous = tailNode;  // rightNode 4 previous node should be tailNode 2
			tailNode.Next = rightNode;      // tailNode 2 next node should be rightNode 4
		}


		return convertedNode;
	}

	// tail dll node
	private static DoublyLinkedListNode FIndTailNodeInDLL(DoublyLinkedListNode node)
	{
		while (node.Next != null)
		{
			node = node.Next;
		}
		return node;
	}
}

public class DoublyLinkedListNode
{
	public int Data { get; set; }
	public DoublyLinkedListNode Next { get; set; }
	public DoublyLinkedListNode Previous { get; set; }
}


public class TreeNode
{
	public TreeNode(int v)
	{
		Data = v;
	}
	public int Data { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
}
