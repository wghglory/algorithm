using System;
using System.Collections.Generic;

class Program
{

	static void Main(string[] args)
	{
		BinaryTree<int> tree = new BinaryTree<int>();
		var a = tree.Root;
		tree.InsertSortedList(new List<int> { 1, 2, 3, 4, 5, 6 });
		var b = tree.Root;

		Console.ReadKey();
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

	private void InsertSortedListRec(IList<T> items, BinaryTreeNode<T> curNode, int l, int r)
	{
		var mid = (l + r) / 2;
		curNode.Value = items[mid];

		if (mid - 1 >= l)
		{
			curNode.Left = new BinaryTreeNode<T>();
			InsertSortedListRec(items, curNode.Left, l, mid - 1);
		}

		if (mid + 1 <= r)
		{
			curNode.Right = new BinaryTreeNode<T>();
			InsertSortedListRec(items, curNode.Right, mid + 1, r);
		}
	}

	public void InsertSortedList(IList<T> items)
	{
		InsertSortedListRec(items, Root, 0, items.Count - 1);
	}
}