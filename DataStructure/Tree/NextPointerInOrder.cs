using System;
using System.Collections.Generic;

/* add Next pointer when inorder traversal */

public class Node
{
    public int Data;
    public Node Left, Right, Next;

    public Node(int item)
    {
        Data = item;
        Left = Right = null;
    }
}

public class BinaryTree
{
    Node Root;

    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Root = new Node(10);
        tree.Root.Left = new Node(5);
        tree.Root.Right = new Node(12);
        tree.Root.Left.Left = new Node(3);
        tree.Root.Left.Right = new Node(8);
        tree.Root.Right.Left = new Node(11);


        //		  10
        //		/    \
        //	   5      12
        //    / \    /
        //   3   8  11

//        InOrder(tree.Root);

        //currentData: 3, nextData: 5
        //currentData: 5, nextData: 8
        //currentData: 8, nextData: 10
        //currentData: 10, nextData: 11
        //currentData: 11, nextData: 12

        InOrderIterative(tree.Root);
    }

    /* prev is a global/static variable*/
    static Node prev;

    static void InOrder(Node root)
    {
        if (root == null) return;

        InOrder(root.Left);

        if (prev != null)
        {
            prev.Next = root;
            Console.Write($"currentData:{prev.Data}, nextData:{prev.Next.Data} \n");
        }

        prev = root;


        InOrder(root.Right);
    }

    //iterative Inorder
    public static void InOrderIterative(Node node)
    {
        if (node == null) return;

        Node root = node;

        Stack<Node> s = new Stack<Node>();

        //push Left path 7-4-2-1, 1 is top
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
        9 has Left, inner while loop push 8, stack 9-8,
        8 pop, then 9 pop, stack empty, 9 has rightchild 10, 10 push and pop
        */
        int prev = int.MinValue;
        Node prevNode = null;
        while (s.Count > 0)
        {
            Node current = s.Pop();

            Console.Write($"current:{current.Data}, prev:{prev} \n");
            if (prevNode != null) prevNode.Next = current;

            Node rightChildOfCurrnet = current.Right;

            //take 7-8-9 for example
            //current is 7, rightChildOfCurrent 9, we need to push 10 first, then 8
            while (rightChildOfCurrnet != null)
            {
                s.Push(rightChildOfCurrnet);
                rightChildOfCurrnet = rightChildOfCurrnet.Left;
            }

            prev = current.Data;
            prevNode = current;
        }

        TestNextPointer(root);
    }

    private static void TestNextPointer(Node root)
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
}
