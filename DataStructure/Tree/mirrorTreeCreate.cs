using System;
using System.Collections.Generic;

public class Program
{

	public static void Main(string[] args)
	{

		TreeNode<int> root = new TreeNode<int>(1);
		TreeNode<int> x1 = new TreeNode<int>(2);
		TreeNode<int> y1 = new TreeNode<int>(3);
		root.Left = x1;
		root.Right = y1;
		root.Left.Left = new TreeNode<int>(4);
		root.Right.Left = new TreeNode<int>(6);
		TreeNode<int> x2 = new TreeNode<int>(7);
		TreeNode<int> y2 = new TreeNode<int>(9);
		root.Right.Left.Left = new TreeNode<int>(8);
		root.Right.Left.Right = y2;
		root.Left.Left.Left = x2;

		//	     1
		// 	    / \
		//     2   3
		//    /   /
		//   4   6
		//  /   / \
		// 7   8   9


		BFS(root);

		mirrorTree(root);

		Console.WriteLine("---------mirrorTree----------");

		BFS(root);
	}

	// PreOrder and swap
	public static void mirrorTree(TreeNode<int> node)
	{
		if (node == null) return;
		TreeNode<int> temp = node.Left;
		node.Left = node.Right;
		node.Right = temp;
		mirrorTree(node.Left);
		mirrorTree(node.Right);
	}

	public static void BFS(TreeNode<int> root)
	{
		Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();

		if (root != null)
		{
			queue.Enqueue(root);

			while (queue.Count != 0)
			{

				var node = queue.Dequeue();

				Console.Write($"{node.Data} ");

				if (node.Left != null)
				{
					queue.Enqueue(node.Left);
				}

				if (node.Right != null)
				{
					queue.Enqueue(node.Right);
				}
			}
		}

	}

}


public class TreeNode<T>
{
	public T Data;
	public TreeNode<T> Left;
	public TreeNode<T> Right;

	public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
	{
		this.Data = data;
		this.Left = left;
		this.Right = right;
	}

	public TreeNode(T data)
	{
		this.Data = data;
		this.Left = null;
		this.Right = null;
	}

	public TreeNode() { }

	public int CountChildren(TreeNode<T> node)
	{
		if (node == null)
			return 0;
		return 1 + CountChildren(node.Left) + CountChildren(node.Right);
	}


}
