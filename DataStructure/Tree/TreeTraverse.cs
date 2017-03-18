using System;
using System.Collections.Generic;

class Program
{

	static void Main(string[] args)
	{
		BinaryTreeNode<int> n1 = new BinaryTreeNode<int> { Value = 60 };
		BinaryTreeNode<int> n2 = new BinaryTreeNode<int> { Value = 30 };
		BinaryTreeNode<int> n3 = new BinaryTreeNode<int> { Value = 30 };
		BinaryTreeNode<int> n4 = new BinaryTreeNode<int> { Value = 20 };
		BinaryTreeNode<int> n5 = new BinaryTreeNode<int> { Value = 50 };
		BinaryTreeNode<int> n6 = new BinaryTreeNode<int> { Value = 50 };
		BinaryTreeNode<int> n7 = new BinaryTreeNode<int> { Value = 20 };
		BinaryTreeNode<int> n8 = new BinaryTreeNode<int> { Value = 15 };
		BinaryTreeNode<int> n9 = new BinaryTreeNode<int> { Value = 15 };

		BinaryTree<int> tree = new BinaryTree<int>();
		tree.Root = n1;
		tree.Root.Left = n2;
		tree.Root.Right = n3;
		tree.Root.Left.Left = n4;
		tree.Root.Left.Right = n5;
		tree.Root.Left.Right.Left = n8;
		tree.Root.Right.Left = n6;
		tree.Root.Right.Left.Right = n9;
		tree.Root.Right.Right = n7;

		var list = Traverse(n1);

		foreach (var l in list)
		{
			Console.Write(l + " ");
		}


		Console.ReadKey();
	}

	public static List<int> Traverse(BinaryTreeNode<int> root)
	{
		Queue<BinaryTreeNode<int>> queue = new Queue<BinaryTreeNode<int>>();
		List<int> result = new List<int>();

		queue.Enqueue(root);

		while (queue.Count != 0)
		{
			BinaryTreeNode<int> node = queue.Dequeue();
			result.Add(node.Value);


			if (node.Left != null)
			{
				queue.Enqueue(node.Left);
			}

			if (node.Right != null)
			{
				queue.Enqueue(node.Right);
			}
		}

		return result;
	}

}

public class BinaryTreeNode<T>
{
	public BinaryTreeNode<T> Right { get; set; }
	public BinaryTreeNode<T> Left { get; set; }
	public T Value { get; set; }
}

public class BinaryTree<T>
{
	public BinaryTree()
	{
		Root = new BinaryTreeNode<T>();
	}

	public BinaryTreeNode<T> Root { get; set; }
}