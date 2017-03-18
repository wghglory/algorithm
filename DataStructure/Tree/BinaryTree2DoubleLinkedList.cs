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

		var res1 = binaryTreeToList.ToDoubleLinkedListNode(root);
		Console.WriteLine(0 == res1.Value);
		Console.WriteLine(2 == res1.Next.Value);

		Console.ReadKey();
	}


}


public class Convert
{
	public DoubleLinkedListNode ToDoubleLinkedListNode(TreeNode root)
	{
		if (root == null) { return null; }

		DoubleLinkedListNode convertedNode = new DoubleLinkedListNode { Value = root.Value };

		if (root.Left != null)
		{
			var leftNode = ToDoubleLinkedListNode(root.Left);
			leftNode.Previous = convertedNode;
			convertedNode.Next = leftNode;
		}

		if (root.Right == null) { return convertedNode; }

		var rightNode = ToDoubleLinkedListNode(root.Right);

		DoubleLinkedListNode lastNextNode = FindLastNextNode(convertedNode);
		rightNode.Previous = lastNextNode;
		lastNextNode.Next = rightNode;

		return convertedNode;
	}
	private static DoubleLinkedListNode FindLastNextNode(DoubleLinkedListNode node)
	{
		while (node.Next != null)
		{
			node = node.Next;
		}
		return node;
	}
}

public class DoubleLinkedListNode
{
	public int Value { get; set; }
	public DoubleLinkedListNode Next { get; set; }
	public DoubleLinkedListNode Previous { get; set; }
}


public class TreeNode
{
	public TreeNode(int v)
	{
		Value = v;
	}
	public int Value { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
}