using System;
/**
* Date 07/07/2014
* @author tusroy
*
* Youtube link - https://youtu.be/bmaeYtlO2OE
* Youtube link - https://youtu.be/_SiwrPXG9-g
* Youtube link - https://youtu.be/NA8B84DZYSA
*
*/

public class Node
{
    public Node Left;
    public Node Right;
    public int Data;

    public Node(int data)
    {
        Data = data;
    }
}

public class BinarySearchTree
{
    public Node AddNode(Node node, int data)
    {
        Node root = node;

        if (node == null)
        {
            node = new Node(data);
            return node;
        }

        Node leaf = null;  //the leaf that will add new node
        while (node != null)
        {
            leaf = node;
            if (node.Data < data) node = node.Right;
            else node = node.Left;
        }

        //add new data to left or right leaf
        if (leaf.Data < data) leaf.Right = new Node(data);
        else leaf.Left = new Node(data);

        return root;  //not the new added node
    }

    public int Height(Node root)
    {
        if (root == null)
        {
            return -1;
        }

        return Math.Max(Height(root.Left), Height(root.Right)) + 1;
    }

    public static void Main(string[] args)
    {
        BinarySearchTree bt = new BinarySearchTree();
        Node root = null;

        root = bt.AddNode(root, 10);
        root = bt.AddNode(root, 15);
        root = bt.AddNode(root, 5);
        root = bt.AddNode(root, 7);
        root = bt.AddNode(root, 19);
        root = bt.AddNode(root, 20);
        root = bt.AddNode(root, -1);
        root = bt.AddNode(root, 21);

        Console.WriteLine(bt.Height(root));

        Node root2 = List2Bst(null, new[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 7 - 1);
        Console.WriteLine(bt.Height(root2));
        Console.ReadKey();
    }

    private static Node List2Bst(Node root, int[] arr, int left, int right)
    {
        if (root != null) return null;

        int mid = (left + right) / 2;

        root = new Node(arr[mid]);

        if (left <= mid - 1) root.Left = List2Bst(root.Left, arr, left, mid - 1);
        if (mid + 1 <= right) root.Right = List2Bst(root.Right, arr, mid + 1, right);

        return root;
    }
}
