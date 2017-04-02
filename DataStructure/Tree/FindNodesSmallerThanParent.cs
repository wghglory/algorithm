using System;
using System.Collections.Generic;

namespace FindNodesSmallerThanParent
{
	class MainClass
	{
		/* Assuming you have a binary tree which stores integers,
		 * count the number of nodes whose value is lower than
		 * the value of its upper nodes.
		*/
		public static void Main()
		{
			TreeNode<int> root = DefineDataNode();
			Console.Write(CountSmallerNodesNum(root));

			Console.Write(CountSmaller(root, int.MinValue));
			Console.WriteLine(string.Join(",", smaller));

			Console.ReadKey();
		}

		public static List<int> smaller = new List<int>();
		public static int count;
		static int CountSmaller(TreeNode<int> node, int pVal)
		{
			if (node == null) return 0;

			if (node.Data < pVal)
			{
				count++;
				smaller.Add(node.Data);
			}

			CountSmaller(node.Left, node.Data);
			CountSmaller(node.Right, node.Data);

			return count;
		}

		public static int CountSmallerNodesNum(TreeNode<int> node)   //DFS
		{
			if (node == null)
			{
				return 0;
			}
			HashSet<TreeNode<int>> hashset = new HashSet<TreeNode<int>>();
			CountNumLesserNodes(node.Left, node.Data, hashset);
			CountNumLesserNodes(node.Right, node.Data, hashset);
			return hashset.Count;
		}

		public static void CountNumLesserNodes(TreeNode<int> node, int pVal, HashSet<TreeNode<int>> hashset)
		{
			if (node == null)
			{
				return;
			}
			if (node.Data < pVal)
			{
				hashset.Add(node);
				pVal = node.Data;
			}
			CountNumLesserNodes(node.Left, pVal, hashset);
			CountNumLesserNodes(node.Right, pVal, hashset);
		}


		private static TreeNode<int> DefineDataNode()
		{
			//			89
			//		  /    \
			//		55		67
			//     /  \     / \
			//	 34	  58  77   4
			//       /      \
			//		5       15

			TreeNode<int> n1 = new TreeNode<int> { Data = 89 };
			TreeNode<int> n2 = new TreeNode<int> { Data = 55 };
			TreeNode<int> n3 = new TreeNode<int> { Data = 67 };
			TreeNode<int> n4 = new TreeNode<int> { Data = 34 };
			TreeNode<int> n5 = new TreeNode<int> { Data = 58 };
			TreeNode<int> n6 = new TreeNode<int> { Data = 77 };
			TreeNode<int> n7 = new TreeNode<int> { Data = 4 };
			TreeNode<int> n8 = new TreeNode<int> { Data = 5 };
			TreeNode<int> n9 = new TreeNode<int> { Data = 15 };


			n1.Left = n2;
			n1.Right = n3;
			n1.Left.Left = n4;
			n1.Left.Right = n5;
			n1.Left.Right.Left = n8;
			n1.Right.Left = n6;
			n1.Right.Left.Right = n9;
			n1.Right.Right = n7;

			return n1;
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
}

public class DFS<T>  //Depth first search, recursion
{

	public void PreOrder(TreeNode<T> node)
	{
		if (node == null) return;
		Visit(node);
		PreOrder(node.Left);
		PreOrder(node.Right);
	}

	public void InOrder(TreeNode<T> node)
	{
		if (node == null) return;
		InOrder(node.Left);
		Visit(node);
		InOrder(node.Right);
	}

	public void PostOrder(TreeNode<T> node)
	{
		if (node == null) return;
		PostOrder(node.Left);
		PostOrder(node.Right);
		Visit(node);
	}

	private void Visit(TreeNode<T> node)
	{
		Console.Write($"{node.Data} ");
	}
}

public class BFS<T>  //breath first search, queue while
{
	Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

	public void Traversal(TreeNode<T> root)
	{
		if (root != null)
		{
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				TreeNode<T> node = queue.Dequeue();

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
