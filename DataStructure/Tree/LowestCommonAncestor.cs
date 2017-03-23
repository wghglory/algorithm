using System;

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


	}

	// * Time complexity O(n)
	// * Space complexity O(h)
	//https://www.youtube.com/watch?v=13m9ZCB8gjw
	//https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/LowestCommonAncestorInBinaryTree.java
	public static TreeNode<int> LowestCommonAncestor(TreeNode<int> root, TreeNode<int> a, TreeNode<int> b)
	{
		if (root == null)
		{
			return null;
		}

		// If the root is one of a or b, then it is the LCA
		if (root == a || root == b)
		{
			return root;
		}

		TreeNode<int> left = LowestCommonAncestor(root.Left, a, b);
		TreeNode<int> right = LowestCommonAncestor(root.Right, a, b);

		// If both nodes lie in left or right then their LCA is in left or right,
		// Otherwise root is their LCA
		if (left != null && right != null)
		{
			return root;
		}

		return (left != null) ? left : right;
	}

	// another idea: find path of node a and node b. Then compare these 2 list, not good as above

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
