using System;
using System.Collections.Generic;

namespace BinaryTreeTraversal
{
	class MainClass
	{
		public static void Main()
		{
			TreeNode<string> root = defineDataNode();
			DFS<string> dfs_traversal = new DFS<string>();

			Console.WriteLine("\n================DFS Inorder===================");
			dfs_traversal.InOrder(root);

			Console.WriteLine("\n================DFS preorder===================");
			dfs_traversal.PreOrder(root);

			Console.WriteLine("\n================DFS postorder===================");
			dfs_traversal.PostOrder(root);

			Console.WriteLine("\n============BFS result=======================");

			BFS<string> bfs_traversal = new BFS<string>();
			bfs_traversal.Traversal(root);
		}

		private static TreeNode<string> defineDataNode()
		{

			//          F
			//        /   \
			//       B     G
			//      / \     \
			//     A   D     I
			//        / \    /\
			//       C   E  H  J


			//TreeNode<string> node = new TreeNode<string>();
			//node.Data = "F";
			//node.Right = new TreeNode<string>();
			//node.Left = new TreeNode<string>();
			//node.Left.Data = "B";
			//node.Right.Data = "G";

			//node.Right.Right = new TreeNode<string>();
			//node.Right.Right.Right = new TreeNode<string>();
			//node.Left.Left = new TreeNode<string>();
			//node.Left.Right = new TreeNode<string>();
			//node.Left.Right.Left = new TreeNode<string>();
			//node.Left.Right.Right = new TreeNode<string>();

			//node.Left.Left.Data = "A";
			//node.Left.Right.Data = "D";
			//node.Left.Right.Left.Data = "C";
			//node.Left.Right.Right.Data = "E";

			//node.Right.Right.Data = "I";
			//node.Right.Right.Left = new TreeNode<string>();
			//node.Right.Right.Left.Data = "H";
			//node.Right.Right.Right.Data = "J";

			TreeNode<string> node =
				new TreeNode<string>("F",
									 new TreeNode<string>("B",
														  new TreeNode<string>("A"),
														  new TreeNode<string>("D",
																				  new TreeNode<string>("C"),
																				  new TreeNode<string>("E")
																			  )
														 ),
									 new TreeNode<string>("G",
														  null,
														  new TreeNode<string>("I",
																				  new TreeNode<string>("H"),
																				  new TreeNode<string>("J")
																			  )
														 )
									);

			return node;
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
		if (root == null) return;

		queue.Enqueue(root);

		while (queue.Count != 0)
		{
			TreeNode<T> node = queue.Dequeue();

			Console.Write($"{node.Data} ");

			if (node.Left != null) queue.Enqueue(node.Left);
			if (node.Right != null) queue.Enqueue(node.Right);
		}

	}
}
