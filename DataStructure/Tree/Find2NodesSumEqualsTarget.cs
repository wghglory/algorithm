using System;
using System.Collections.Generic;


/**
 * http://codercareer.blogspot.com/2013/03/no-46-nodes-with-sum-in-binary-search.html

 if 2 nodes sum equals to target in BST
 solution idea comes from 2 values in sorted array sum up to target:
 minPointer and maxPointer, sum of them compares with target, then decide move which pointer
*/
public class HasTwoNodesEqualsSumBST
{

	bool hasTwoNodes(Node node, int target)
	{
		Stack<Node> nextNodes = new Stack<Node>();  //store smaller values
		Stack<Node> prevNodes = new Stack<Node>();  //store bigger values
		buildNextNodes(node, nextNodes);    // nextNodes: top->bottom: 1 2 5    nextNodes[0] is top 1
		buildPrevNodes(node, prevNodes);    // prevNodes: top->bottom: 12 10 5

		Node pNext = getNext(nextNodes); // init minPointer
		Node pPrev = getPrev(prevNodes); // init maxPointer

		while (pNext != null && pPrev != null && pNext != pPrev)
		{
			int currentSum = pNext.Data + pPrev.Data;
			if (currentSum == target)
				return true;

			if (currentSum < target)
				pNext = getNext(nextNodes);
			else
				pPrev = getPrev(prevNodes);
		}

		return false;
	}

	void buildNextNodes(Node node, Stack<Node> nodes)
	{
		while (node != null)
		{
			nodes.Push(node);
			node = node.Left;
		}
	}

	void buildPrevNodes(Node node, Stack<Node> nodes)
	{
		while (node != null)
		{
			nodes.Push(node);
			node = node.Right;
		}
	}

	Node getNext(Stack<Node> nodes)
	{
		Node popNode = null;
		if (leftStack.Count > 0)
		{
			popNode = leftStack.Pop();
			Node rightOfPopNode = popNode.Right;
			while (rightOfPopNode != null)
			{
				leftStack.Push(rightOfPopNode);
				rightOfPopNode = rightOfPopNode.Left;
			}
		}
		return popNode;
	}

	Node getPrev(Stack<Node> nodes)
	{
		Node popNode = null;
		if (rightStack.Count > 0)
		{
			popNode = rightStack.Pop();
			Node leftOfPopNode = popNode.Left;
			while (leftOfPopNode != null)
			{
				rightStack.Push(leftOfPopNode);
				leftOfPopNode = leftOfPopNode.Right;
			}
		}
		return popNode;
	}

	public static void Main(string[] args)
	{
		Node root = DefineBST();
		HasTwoNodesEqualsSum h = new HasTwoNodesEqualsSum();
		Console.WriteLine(h.hasTwoNodes(root, 22));
	}

	private static Node DefineBST()
	{

		//          5
		//        /   \
		//       2     10
		//      / \    / \
		//     1   3   7  12
		//             /\
		//            6  8


		Node node = new Node();
		node.Data = 5;
		node.Right = new Node();
		node.Left = new Node();

		node.Left.Data = 2;
		node.Right.Data = 10;

		node.Left.Left = new Node();
		node.Left.Right = new Node();
		node.Left.Left.Data = 1;
		node.Left.Right.Data = 3;

		node.Right.Left = new Node();
		node.Right.Right = new Node();
		node.Right.Left.Data = 7;
		node.Right.Right.Data = 12;

		node.Right.Left.Left = new Node();
		node.Right.Left.Right = new Node();
		node.Right.Left.Left.Data = 6;
		node.Right.Left.Right.Data = 8;

		return node;
	}
}


public class Node
{
	public int Data;
	public Node Left;
	public Node Right;

	public Node(int Data, Node Left, Node Right)
	{
		this.Data = Data;
		this.Left = Left;
		this.Right = Right;
	}

	public Node(int Data)
	{
		this.Data = Data;
		this.Left = null;
		this.Right = null;
	}

	public Node() { }
}
