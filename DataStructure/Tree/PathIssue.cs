using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Node root = new Node(11);
        Node x1 = new Node(2);
        Node y1 = new Node(3);
        root.Left = x1;
        root.Right = y1;
        root.Left.Left = new Node(4);
        root.Right.Left = new Node(6);
        Node x2 = new Node(7);
        Node y2 = new Node(9);
        Node z2 = new Node(8);
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


        //         print path for a given node
        PrintPathTillTarget(root, z2);
        PathOfTarget.Reverse();
        Console.WriteLine(string.Join("-->", PathOfTarget) + "\n");

        //        print path that sums equals to sum
        PrintPathEqualsSum(root, 14);
        PathOfSum.Reverse();
        Console.WriteLine(string.Join("-->", PathOfSum) + "\n");

        //        print path until leaf that sums equals to sum
        PathOfSum.Clear();
        PrintPathUntilLeafEqualsSum(root, 24);
        PathOfSum.Reverse();
        Console.WriteLine(string.Join("-->", PathOfSum) + "\n");

        //        print all paths
        PrintAllPath2Leaf(root, new int[100], 0);
    }


    static List<int> PathOfTarget = new List<int>();

    private static bool PrintPathTillTarget(Node node, Node target)
    {
        if (node == null) return false;

        if (node.Data == target.Data || PrintPathTillTarget(node.Left, target) ||
            PrintPathTillTarget(node.Right, target))
        {
            PathOfTarget.Add(node.Data);
            return true;
        }
        else
        {
            return false;
        }
    }

    static List<int> PathOfSum = new List<int>();

    private static bool PrintPathUntilLeafEqualsSum(Node node, int sum)
    {
        if (node == null) return false;

        //leaf and sum satisfy requirement
        if (node.Left == null && node.Right == null && node.Data == sum)
        {
            PathOfSum.Add(node.Data);
            return true;
        }

        if (PrintPathUntilLeafEqualsSum(node.Left, sum - node.Data) ||
            PrintPathUntilLeafEqualsSum(node.Right, sum - node.Data))
        {
            PathOfSum.Add(node.Data);
            return true;
        }

        return false;
    }

    private static bool PrintPathEqualsSum(Node node, int sum)
    {
        if (node == null) return false;

        // sum satisfy requirement
        if (node.Data == sum)
        {
            PathOfSum.Add(node.Data);
            return true;
        }

        if (PrintPathEqualsSum(node.Left, sum - node.Data) || PrintPathEqualsSum(node.Right, sum - node.Data))
        {
            PathOfSum.Add(node.Data);
            return true;
        }

        return false;
    }


    private static void PrintAllPath2Leaf(Node root, int[] arr, int len)
    {
        if (root == null) return;

        arr[len] = root.Data;
        if (root.Left == null && root.Right == null)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write(arr[i] + "-->");
            }
            Console.Write(arr[len] + "\n");
        }

        len++;

        PrintAllPath2Leaf(root.Left, arr, len);
        PrintAllPath2Leaf(root.Right, arr, len);
    }
}

public class Node
{
    public int Data { get; set; }

    public Node Left { get; set; }
    public Node Right { get; set; }

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
        while (s.Count > 0)
        {
            Node current = s.Pop();
            Console.Write(current.Data + " ");
            Node rightChildOfCurrnet = current.Right;

            //take 7-8-9 for example
            //current is 7, rightChildOfCurrent 9, we need to push 10 first, then 8
            while (rightChildOfCurrnet != null)
            {
                s.Push(rightChildOfCurrnet);
                rightChildOfCurrnet = rightChildOfCurrnet.Left;
            }
        }
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
