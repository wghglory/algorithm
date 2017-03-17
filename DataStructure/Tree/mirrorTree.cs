using System;

class Program
{
	static void Main(string[] args)
	{
		#region complex solultion
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

		Console.WriteLine(IsTreeMirrored(tree));
		#endregion

		#region simple solultion
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

		Console.WriteLine(IsTreeMirrored(tree));
		#endregion

		Console.ReadKey();
	}

	#region complex solultion

	private static bool CompareLeftRight(BinaryTreeNode<int> n1, BinaryTreeNode<int> n2)
	{
		if (n1 == null && n2 == null)
		{
			return true;
		}

		if (n1 == null || n2 == null)
		{
			return false;
		}

		return n1.Value == n2.Value &&
		CompareLeftRight(n1.Left, n2.Right) &&
		CompareLeftRight(n1.Right, n2.Left);
	}

	public static bool IsTreeMirrored(BinaryTree<int> tree)
	{
		bool ret = false;
		if (tree != null)
		{
			ret = CompareLeftRight(tree.Root.Left, tree.Root.Right);
		}
		return ret;
	}
	#endregion

	#region simple solultion
	private static bool CompareLeftRight(BinaryTreeNode n1, BinaryTreeNode n2)
	{
		if (n1 == null && n2 == null)
		{
			return true;
		}

		if (n1 == null || n2 == null)
		{
			return false;
		}

		return n1.Value == n2.Value &&
		CompareLeftRight(n1.Left, n2.Right) &&
		CompareLeftRight(n1.Right, n2.Left);
	}

	public static bool IsTreeMirrored(BinaryTreeNode node)
	{
		bool ret = false;
		if (node != null)
		{
			ret = CompareLeftRight(node.Left, node.Right);
		}
		return ret;
	}
	#endregion
}

public class BinaryTreeNode<T>
{
	public T Value { get; set; }
	public BinaryTreeNode<T> Left { get; set; }
	public BinaryTreeNode<T> Right { get; set; }
}

public class BinaryTree<T>
{
	public BinaryTreeNode<T> Root { get; set; }
}

// simple
public class BinaryTreeNode
{
	public int Value { get; set; }
	public BinaryTreeNode Left { get; set; }
	public BinaryTreeNode Right { get; set; }
}
