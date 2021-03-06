using System;
using System.Collections.Generic;

public class Program
{
	public static void Main(string[] args)
	{
		TreeNode<int> root = new TreeNode<int>(11);
		TreeNode<int> x1 = new TreeNode<int>(2);
		TreeNode<int> y1 = new TreeNode<int>(3);
		root.Left = x1;
		root.Right = y1;
		root.Left.Left = new TreeNode<int>(4);
		root.Right.Left = new TreeNode<int>(6);
		TreeNode<int> x2 = new TreeNode<int>(7);
		TreeNode<int> y2 = new TreeNode<int>(9);
		TreeNode<int> z2 = new TreeNode<int>(8);
		root.Right.Left.Left = y2;
		root.Right.Left.Right = z2;
		root.Left.Left.Left = x2;

		//	     11
		// 	    / \
		//     2   3
		//    /   /
		//   4   6
		//  /   / \
		// 7   8   9


		TreeNode<int> ancestor = LowestCommonAncestor(root, z2, y2);
		Console.Write(ancestor.Data);

		// print path for a given node
		PrintPath(root, z2);
		path.Reverse();
		Console.WriteLine(string.Join("-->", path));
	}

	// * Time complexity O(n)
	// * Space complexity O(h)
	//https://www.youtube.com/watch?v=13m9ZCB8gjw
	//https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/LowestCommonAncestorInBinaryTree.java
	public static TreeNode<int> LowestCommonAncestor(TreeNode<int> node, TreeNode<int> a, TreeNode<int> b)
	{
		if (node == null)
		{
			return null;
		}

		// If the root is one of a or b, then it is the LCA
		if (node == a || node == b)
		{
			return node;
		}

		TreeNode<int> left = LowestCommonAncestor(node.Left, a, b);
		TreeNode<int> right = LowestCommonAncestor(node.Right, a, b);

		// If both nodes lie in left or right then their LCA is in left or right,
		// Otherwise root is their LCA
		if (left != null && right != null) return node;
		if (left == null && right == null) return null;  //leaf

		return (left != null) ? left : right;
	}

	// another idea: find path of node a and node b. Then compare these 2 list, not good as above because of space
	public static List<int> path = new List<int>();
	public static bool PrintPath(TreeNode<int> root, TreeNode<int> targetNode)
	{
		if (root == null) return false;

		if (root == targetNode || PrintPath(root.Left, targetNode) || PrintPath(root.Right, targetNode))
		{
			//Console.Write("  " + root.data);
			path.Add(root.Data);
			return true;
		}

		return false;
	}

}


//https://www.youtube.com/watch?v=TIoCCStdiFo
public class LowestCommonAncestoryBinarySearchTree
{

	public TreeNode<int> lowestCommonAncestor(TreeNode<int> root, int p, int q)
	{
		if (root.Data > Math.Max(p, q))
		{
			return lowestCommonAncestor(root.Left, p, q);
		}
		else if (root.Data < Math.Min(p, q))
		{
			return lowestCommonAncestor(root.Right, p, q);
		}
		else
		{
			return root;
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
