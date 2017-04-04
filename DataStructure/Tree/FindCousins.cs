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

		CheckIfTwoNodesAreCousins i = new CheckIfTwoNodesAreCousins();
		Console.WriteLine("Node " + x1.Data + " and Node " + y1.Data + " are cousins? " + i.areCousins(root, x1, y1));
		Console.WriteLine("Node " + x2.Data + " and Node " + y2.Data + " are cousins? " + i.areCousins(root, x2, y2));


		FindCousins f = new FindCousins();
		var cousinList = f.GetCousins(root, x2);  // 7 cousins are 8 and 9
		foreach (var l in cousinList)
		{
			Console.WriteLine(l);
		}

		// attention: GetCousins and GetBrother should not appear same time since they share the same recursive call. List will be filled in twice
		//var brotherAndSelf = f.GetBrother(root, y2);
		//foreach (var l in brotherAndSelf)
		//{
		//	Console.WriteLine(l);
		//}

	}

}


// find cousins for a specific node
// thought: 1. getHeight of the given node, 2. traverse tree and find all nodes in same level, except the one shares same parent
public class FindCousins
{
	List<int> CousinList = new List<int>();
	List<int> BrotherAndSelf = new List<int>();

	public List<int> GetCousins(TreeNode<int> root, TreeNode<int> givenNode)
	{
		int level = getHeight(root, givenNode, 1);
		InOrderTraverse(root, level, root, givenNode);

		return CousinList;
	}

	public List<int> GetBrother(TreeNode<int> root, TreeNode<int> givenNode)
	{
		int level = getHeight(root, givenNode, 1);
		InOrderTraverse(root, level, root, givenNode);

		return BrotherAndSelf;
	}

	private void InOrderTraverse(TreeNode<int> node, int level, TreeNode<int> root, TreeNode<int> givenNode)
	{
		if (node == null)
			return;

		InOrderTraverse(node.Left, level, root, givenNode);

		if (getHeight(root, node, 1) == level && !sameParents(root, node, givenNode))
		{
			CousinList.Add(node.Data);
		}
		else if (getHeight(root, node, 1) == level && sameParents(root, node, givenNode))
		{
			BrotherAndSelf.Add(node.Data);
		}

		InOrderTraverse(node.Right, level, root, givenNode);
	}

	// get level/depth/height of a given node
	private int getHeight(TreeNode<int> root, TreeNode<int> givenNode, int height)
	{
		if (root == null)  return 0;

		if (root == givenNode)  return height;

		int level = getHeight(root.Left, givenNode, height + 1);

		if (level != 0)  return level;  //givenNode is not on left node

		level = getHeight(root.Right, givenNode, height + 1);

		return level;
	}

	private bool sameParents(TreeNode<int> root, TreeNode<int> x, TreeNode<int> y)
	{
		if (root == null)
			return false;

		if (x == y)
		{
			//self:
			return true;
		}

		return ((root.Left == x && root.Right == y)
				|| (root.Left == y && root.Right == x)
				|| sameParents(root.Left, x, y)
				|| sameParents(root.Right, x, y));
	}
}


// another thought for below question
// define node class like data, left, right, parent, depth
// a.parent != b.parent && a.depth == b.depth => cousins

public class CheckIfTwoNodesAreCousins
{
	public bool areCousins(TreeNode<int> root, TreeNode<int> x, TreeNode<int> y)
	{
		if (getHeight(root, x, 1) == getHeight(root, y, 1) && !areSameParent(root, x, y)) return true;

		return false;
	}

	// get level/depth/height of a given node
	private int getHeight(TreeNode<int> node, TreeNode<int> x, int height)
	{
		if (node == null)
			return 0;

		if (node == x)
			return height;

		int level = getHeight(node.Left, x, height + 1);

		if (level != 0)
			return level;

		level = getHeight(node.Right, x, height + 1);

		return level;
	}

	// longest height from root to leaf
	static int Height(BinaryTreeNode<int> root)
	{
		if (root == null)
		{
			return -1;
		}
		else
		{
			return 1 + Math.Max(Height(root.Left), Height(root.Right));
		}
	}

	private bool sameParents(TreeNode<int> root, TreeNode<int> x, TreeNode<int> y)
	{
		if (root == null)
			return false;

		return ((root.Left == x && root.Right == y)
				|| (root.Left == y && root.Right == x)
				|| sameParents(root.Left, x, y)
				|| sameParents(root.Right, x, y));
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
