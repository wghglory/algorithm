using System;
using System.Collections.Generic;

/*find max consecutive number sequence length*/
public class Program
{
	public static void Main(string[] args)
	{
		BinaryTree bt = new BinaryTree();
		Node root = bt.BuildBST();

		Console.Write(MaxSeqLen(root, root.Data, 1, 1));  //3: 4-5-6
	}

	// DFS
	// node value == parentnode value + 1
	private static int MaxSeqLen(Node root, int pVal, int currentSeqLen, int maxSeqLen)
	{
		if (root == null) return 0;

		if (root.Data == pVal + 1) currentSeqLen++;
		else currentSeqLen = 1;

		maxSeqLen = Math.Max(maxSeqLen, currentSeqLen);

		int leftMax = MaxSeqLen(root.Left, root.Data, currentSeqLen, maxSeqLen);
		int rightMax = MaxSeqLen(root.Right, root.Data, currentSeqLen, maxSeqLen);

		return Math.Max(maxSeqLen, Math.Max(leftMax, rightMax));
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Left { get; set; }
	public Node Right { get; set; }
	public Node Next { get; set; }

	public Node(int data)
	{
		Data = data;
	}

	public Node()
	{
	}
}


public class BinaryTree
{
	public Node Root { get; set; }

	public Node BuildBT()
	{
		Node root = new Node(1);
		root.Left = new Node(2);
		root.Right = new Node(5);

		root.Left.Left = new Node(3);
		root.Left.Right = new Node(4);

		root.Right.Left = new Node(6);
		root.Right.Right = new Node(7);

		root.Left.Left.Left = new Node(9);
		root.Left.Left.Right = new Node(10);
		root.Left.Right.Right = new Node(12);

		return root;

		/*
                  1
                 / \
                2   5
               /\   /\
              3  4 6  7
             / \  \
            9  10 12
        */
	}

	public Node BuildBST()
	{
		Node root = new Node(7);
		root.Left = new Node(4);
		root.Right = new Node(9);

		root.Left.Left = new Node(2);
		root.Left.Right = new Node(5);

		root.Right.Left = new Node(8);
		root.Right.Right = new Node(10);

		root.Left.Left.Left = new Node(1);
		root.Left.Left.Right = new Node(3);
		root.Left.Right.Right = new Node(6);

		return root;

		/*
                  7
                 / \
                4   9
               /\   /\
              2  5  8 10
             / \  \
            1   3  6
        */
	}

	//add a new node, node is root initially, return root
	public Node AddNodeForBST(Node node, int data)
	{
		if (node == null) return Root = new Node(data);

		Node root = node;
		Node leaf = null;
		while (node != null)
		{
			leaf = node;
			node = data > node.Data ? node.Right : node.Left;
		}

		if (data > leaf.Data) leaf.Right = new Node(data);
		else leaf.Left = new Node(data);

		return root;
	}

	//depth first search
	public void InOrder(Node node)
	{
		if (node == null) return;

		InOrder(node.Left);
		Console.Write(node.Data + " ");
		InOrder(node.Right);
	}

	//depth first search
	public void PreOrder(Node node)
	{
		if (node == null) return;

		Console.Write(node.Data + " ");
		PreOrder(node.Left);
		PreOrder(node.Right);
	}

	//depth first search
	public void PostOrder(Node node)
	{
		if (node == null) return;

		PostOrder(node.Left);
		PostOrder(node.Right);
		Console.Write(node.Data + " ");
	}

	//breadth first search
	public void LevelOrder(Node node)
	{
		if (node == null) return;

		Queue<Node> q = new Queue<Node>();
		q.Enqueue(node);

		while (q.Count > 0)
		{
			Node current = q.Dequeue();

			Console.Write(current.Data + " ");

			if (current.Left != null) q.Enqueue(current.Left);
			if (current.Right != null) q.Enqueue(current.Right);
		}
	}

	//iterative Inorder
	public void InOrderIterative(Node node)
	{
		if (node == null) return;

		Node root = node;

		Stack<Node> s = new Stack<Node>();

		//push left path 7-4-2-1, 1 is top
		//pop small value and push its rightChild and rightChild's leftChild (pop 7, push 9, push 8)
		while (node != null)
		{
			s.Push(node);
			node = node.Left;
		}

		/*InOrder:
              7
             / \
            4   9
           /\   /\
          2  5  8 10
         / \  \
        1   3  6    */

		/*
        thought: every popped node is regarded as parent node (take 7 e.g),
                 push rightChild 9,
                 loop push leftChild of rightChild: 8

        1 pop, 2 pop, now stack 7-4(top),
        3 pushed, stack 7-4-3, 3 pop(console.write, stop because 3 doesn't have rightChild),
        4 pop, stack only 7, 5 as child of 4 is pushed, note: 5 links its rightChild 6
        5 pop, stack only 7, 6 as rightchild of 5 is pushed, stack 7-6
        6 pop, stack only 7,
        7 pop, stack nothing, 9 as rightchild of 7 is pushed, stack 9
        9 has left, inner while loop push 8, stack 9-8,
        8 pop, then 9 pop, stack empty, 9 has rightchild 10, 10 push and pop
        */
		int prev = int.MinValue;
		Node prevNode = null;
		while (s.Count > 0)
		{
			Node current = s.Pop();

			Console.Write($"current:{current.Data}, prev:{prev} \n");
			if (prevNode != null) prevNode.Next = current;

			Node rightChildOfCurrent = current.Right;

			//take 7-8-9 for example
			//current is 7, rightChildOfCurrent 9, we need to push 10 first, then 8
			while (rightChildOfCurrent != null)
			{
				s.Push(rightChildOfCurrent);
				rightChildOfCurrent = rightChildOfCurrent.Left;
			}

			prev = current.Data;
			prevNode = current;
		}

		TestNextPointer(root);
	}

	private void TestNextPointer(Node root)
	{
		while (root.Left != null)
		{
			root = root.Left;
		}
		while (root != null)
		{
			Console.Write(root.Data + " ");
			root = root.Next;
		}
	}


	//depth first search
	private Node prev;
	public void InOrderWithNext(Node node)
	{
		if (node == null) return;

		InOrderWithNext(node.Left);

		if (prev != null)
		{
			prev.Next = node;
			Console.Write($"current:{node.Data}, prev:{prev.Data}\n");
		}
		prev = node;

		InOrderWithNext(node.Right);
	}

	//depth first search
	public void InOrderWithParent(Node node, Node parent)
	{
		if (node == null) return;

		InOrderWithParent(node.Left, node);

		if (parent != null) Console.Write($"current:{node.Data}, parent:{parent.Data}\n");

		InOrderWithParent(node.Right, node);
	}
}


public class InOrderIterator
{
	public InOrderIterator(Node root)
	{
		NodeStack = new Stack<Node>();
		FillStack(root);
	}

	// iterator
	public Stack<Node> NodeStack { get; set; }

	public bool HasNext()
	{
		if (NodeStack.Count > 0) return true;

		return false;
	}

	public Node MoveNext()
	{
		Node node = null;
		if (HasNext())
		{
			node = NodeStack.Pop();
		}
		return node;
	}

	private void FillStack(Node node)
	{
		if (node == null) return;

		FillStack(node.Right);
		NodeStack.Push(node);
		FillStack(node.Left);
	}
}
