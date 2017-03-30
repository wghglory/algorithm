using System;
using System.Collections.Generic;

class Program
{

	static void Main(string[] args)
	{
		BinarySearchtree tree = new BinarySearchtree();
		List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

		//build tree based on all elements, think once
		//tree.InsertSortedList(nums);
		//		3
		//	   /  \
		//    1    5
		//     \  / \
		//     2  4  6

		//tree.InOrder(b);
		//tree.LevelOrder(b);


		//build tree based on previous, one by one
		nums.ForEach(x => tree.AddNode(tree.Root, x));
		//  1
		//   \
		//	  2
		//	   \
		//		3
		//		 \
		//		  4
		//		   \
		//			5
		//			 \
		//			  6

		tree.InOrder(tree.Root);

		Console.ReadKey();
	}

}

public class Node
{
	public Node Right { get; set; }
	public Node Left { get; set; }
	public int Value { get; set; }

	public Node(int data)
	{
		Value = data;
		Right = null;
		Left = null;
	}

	public Node() { }
}

public class BinarySearchtree
{
	public Node Root { get; set; }


	// 1 2 3 4 5 6 7
	//1. pick 4 as root, 123 as left, 567 as right part
	//2. work on 123, pick 2, 1 as left, 3 as right
	//3. work on 567, pick 6, 5 as left, 7 as right
	//    4
	//	 / \
	//	2   6
	//  /\  /\
	//  1 3 5 7
	private void InsertSortedListRec(IList<int> items, Node curNode, int l, int r)
	{
		// mid root
		var mid = (l + r) / 2;
		curNode.Value = items[mid];

		if (mid - 1 >= l)
		{
			curNode.Left = new Node();
			InsertSortedListRec(items, curNode.Left, l, mid - 1);
		}

		if (mid + 1 <= r)
		{
			curNode.Right = new Node();
			InsertSortedListRec(items, curNode.Right, mid + 1, r);
		}
	}

	public void InsertSortedList(IList<int> items)
	{
		InsertSortedListRec(items, Root, 0, items.Count - 1);
	}

	// return root
	public Node AddNode(Node node, int data)
	{
		if (node == null)
		{
			Root = new Node(data);
			return Root;
		}

		Node leaf = null;
		while (node != null)
		{
			leaf = node;

			if (data > node.Value)
			{
				node = node.Right;
			}
			else
			{
				node = node.Left;
			}
		}

		if (data > leaf.Value)
		{
			leaf.Right = new Node(data);
		}
		else
		{
			leaf.Left = new Node(data);
		}
		return node;
	}

	public void InOrder(Node node)
	{
		if (node == null) return;

		InOrder(node.Left);
		Console.WriteLine(node.Value);
		InOrder(node.Right);
	}

	public void LevelOrder(Node node)
	{
		if (node == null) return;

		Queue<Node> q = new Queue<Node>();

		q.Enqueue(node);

		while (q.Count > 0)
		{
			Node n = q.Dequeue();

			Console.WriteLine(n.Value);

			if (n.Left != null) q.Enqueue(n.Left);
			if (n.Right != null) q.Enqueue(n.Right);
		}
	}
}
