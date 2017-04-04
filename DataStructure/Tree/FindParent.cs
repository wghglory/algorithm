using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Node s1 = new Node { Data = 60 };
        Node s2 = new Node { Data = 30 };
        Node s3 = new Node { Data = 30 };
        Node s4 = new Node { Data = 20 };
        Node s5 = new Node { Data = 50 };
        Node s6 = new Node { Data = 50 };
        Node s7 = new Node { Data = 20 };

        s1.Left = s2;
        s1.Right = s3;
        s1.Left.Left = s4;
        s1.Left.Right = s5;
        s1.Right.Left = s6;
        s1.Right.Right = s7;

        Console.WriteLine(Convert.ToInt32(FindParent(s1, 20)));

        FindParentNode(s1, 20);
        Console.WriteLine(parent);

        Console.ReadKey();
    }

    public static int? FindParent(Node root, int target)
    {
        if (root == null || root.Data == target)
            return null;

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var p = queue.Dequeue();

            if (p.Left != null)
            {
                if (p.Left.Data == target)
                    return p.Data;
                queue.Enqueue(p.Left);
            }

            if (p.Right != null)
            {
                if (p.Right.Data == target)
                    return p.Data;
                queue.Enqueue(p.Right);
            }
        }

        return null;
    }

    // find parent value for a given target node
    static int parent = 0;
    private static void FindParentNode(Node root, int target)
    {
        if (root == null) return;

        FindParentNode(root.Left, target);
        if (root.Left != null && root.Left.Data == target) parent = root.Data;

        FindParentNode(root.Right, target);
        if (root.Right != null && root.Right.Data == target) parent = root.Data;
    }

    private static void FindParentNode2(Node root, int target)
    {
        if (root == null) return;

        if (root.Left != null && root.Left.Data == target || root.Right != null && root.Right.Data == target) parent = root.Data;
        FindParentNode2(root.Left, target);
        FindParentNode2(root.Right, target);
    }

    private static void FindParentNode3Best(Node root, Node x)
    {
        if (root == null) return;

        if (root.Left == x || root.Right == x) parent = root.Data;
        FindParentNode3Best(root.Left, x);
        FindParentNode3Best(root.Right, x);
    }

    private static Node FindParentNode4(Node root, Node x)
    {
        if (root == null) return null;

        if (root == x) return null;

        if (root.Left == x || root.Right == x)
        {
            return root;
        }

        Node left = FindParentNode4(root.Left, x);
        if (left != null) return left;

        Node right = FindParentNode4(root.Right, x);
        if (right != null) return right;

        return null;
    }
}

public class Node
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}
