using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		BinaryTreeNode s1 = new BinaryTreeNode { Value = 60 };
		BinaryTreeNode s2 = new BinaryTreeNode { Value = 30 };
		BinaryTreeNode s3 = new BinaryTreeNode { Value = 30 };
		BinaryTreeNode s4 = new BinaryTreeNode { Value = 20 };
		BinaryTreeNode s5 = new BinaryTreeNode { Value = 50 };
		BinaryTreeNode s6 = new BinaryTreeNode { Value = 50 };
		BinaryTreeNode s7 = new BinaryTreeNode { Value = 20 };

		s1.Left = s2;
		s1.Right = s3;
		s1.Left.Left = s4;
		s1.Left.Right = s5;
		s1.Right.Left = s6;
		s1.Right.Right = s7;

		Console.WriteLine(Convert.ToInt32(FindParent(s1, 20)));

		Console.ReadKey();
	}

	public static int? FindParent(BinaryTreeNode root, int target)
	{
		if (root == null || root.Value == target)
			return null;

		var queue = new Queue<BinaryTreeNode>();
		queue.Enqueue(root);

		while (queue.Count > 0)
		{
			var p = queue.Dequeue();

			if (p.Left != null)
			{
				if (p.Left.Value == target)
					return p.Value;
				queue.Enqueue(p.Left);
			}

			if (p.Right != null)
			{
				if (p.Right.Value == target)
					return p.Value;
				queue.Enqueue(p.Right);
			}
		}

		return null;
	}
}

public class BinaryTreeNode
{
	public int Value { get; set; }
	public BinaryTreeNode Left { get; set; }
	public BinaryTreeNode Right { get; set; }
}
