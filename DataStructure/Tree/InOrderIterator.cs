using System;
using System.Collections.Generic;

public class Program
{

	public static void Main(string[] args)
	{

		//          5
		//        /   \
		//       2     10
		//      / \    / \
		//     1   3   7  12
		//             /\
		//            6  7

		TreeNode<int> node = new TreeNode<int>();
		node.Data = 5;
		node.Right = new TreeNode<int>();
		node.Left = new TreeNode<int>();

		node.Left.Data = 2;
		node.Right.Data = 10;

		node.Left.Left = new TreeNode<int>();
		node.Left.Right = new TreeNode<int>();
		node.Left.Left.Data = 1;
		node.Left.Right.Data = 3;

		node.Right.Left = new TreeNode<int>();
		node.Right.Right = new TreeNode<int>();
		node.Right.Left.Data = 7;
		node.Right.Right.Data = 12;

		node.Right.Left.Left = new TreeNode<int>();
		node.Right.Left.Right = new TreeNode<int>();
		node.Right.Left.Left.Data = 6;
		node.Right.Left.Right.Data = 7;  //7, 8


		InOrderIterator<int> itr = new InOrderIterator<int>(node);

		while (itr.hasNext())
		{
			Console.Write(itr.next() + " ");
		}

	}

}

// In-order using iteration
public class InOrderIterator<T>
{
	Stack<TreeNode<T>> s;
	public InOrderIterator(TreeNode<T> t)
	{
		s = new Stack<TreeNode<T>>();
		fillStack(t);
	}
	void fillStack(TreeNode<T> current)
	{
		if (current == null)
			return;
		fillStack(current.Right);
		s.Push(current);
		fillStack(current.Left);
		return;
	}
	public bool hasNext()
	{
		return s.Count > 0;
	}
	public T next()
	{
		if (s.Count == 0)
			return default(T);
		return s.Pop().Data;
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
