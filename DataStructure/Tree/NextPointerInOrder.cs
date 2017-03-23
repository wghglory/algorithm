using System;

/* add next pointer when inorder traversal */

public class Node
{
	public int data;
	public Node left, right, next;

	public Node(int item)
	{
		data = item;
		left = right = null;
	}
}

class BinaryTree
{
	Node root;

	public static void Main(string[] args)
	{
		BinaryTree tree = new BinaryTree();
		tree.root = new Node(10);
		tree.root.left = new Node(5);
		tree.root.right = new Node(12);
		tree.root.left.left = new Node(3);
		tree.root.left.right = new Node(8);
		tree.root.right.left = new Node(11);


		//		  10
		//		/    \
		//	   5      12
		//    / \    /
		//   3   8  11

		inOrder(tree.root);

		//currentData: 3, nextData: 5
		//currentData: 5, nextData: 8
		//currentData: 8, nextData: 10
		//currentData: 10, nextData: 11
		//currentData: 11, nextData: 12

	}

	/* last is a global/static variable*/
	static Node last;
	static void inOrder(Node root)
	{
		if (root == null) return;

		inOrder(root.left);

		if (last != null)
		{
			last.next = root;
			Console.Write($"currentData:{last.data}, nextData:{last.next.data} \n");
		}

		last = root;


		inOrder(root.right);
	}


}
