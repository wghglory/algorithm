using System;
using System.Collections.Generic;
using System.Linq;

/*determine if BST has duplicate values
 * solution: in-order traversal and check if current node value equals to prev
*/
public class FindBSTduplicates
{
	public static void Main(string[] args)
	{
		TreeNode<int> root = DefineBST();

		BFS<int> bfs = new BFS<int>();
		//bfs.Traversal(root);

		DFS<int> dfs = new DFS<int>();

		//dfs.InOrderToList(root);
		//if (dfs.List.Distinct().Count() == dfs.List.Count())
		//{
		//	Console.WriteLine("no duplicates");
		//}
		//else
		//{
		//	Console.WriteLine("has duplicates");
		//}

		//dfs.InOrderToHashSet(root);
		//foreach (var v in dfs.Set)
		//{
		//	Console.WriteLine(v);
		//}

		// issue: don't break when finding a duplicate
		Console.WriteLine(dfs.InOrderCheckDuplicates(root));

		dfs.InOrderFindDuplicates(root);
		foreach (KeyValuePair<int, int> dic in dfs.Dic)
		{
			Console.WriteLine($"{dic.Key}: {dic.Value}");
		}

	}

	private static TreeNode<int> DefineBST()
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

		return node;
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
}

public class DFS<T>  //Depth first search, recursion
{
	public void PreOrder(TreeNode<T> node)
	{
		if (node == null) return;
		Visit(node);
		PreOrder(node.Left);
		PreOrder(node.Right);
	}

	public void InOrder(TreeNode<T> node)
	{
		if (node == null) return;
		InOrder(node.Left);
		Visit(node);
		InOrder(node.Right);
	}

	public List<T> List = new List<T>();
	public HashSet<T> Set = new HashSet<T>();
	public Dictionary<T, int> Dic = new Dictionary<T, int>();

	// add values into list, possible duplicates. can use list.Distinct().Count == list.Count to check if duplicates exist
	public void InOrderToList(TreeNode<T> node)
	{
		if (node != null)
		{
			InOrderToList(node.Left);
			List.Add(node.Data);
			InOrderToList(node.Right);
		}
	}

	// remove duplicates and add values into hashset
	public void InOrderToHashSet(TreeNode<T> node)
	{
		if (node != null)
		{
			InOrderToHashSet(node.Left);
			Set.Add(node.Data);
			InOrderToHashSet(node.Right);
		}
	}

	// check if there is any duplicate, known issue: this continues to call recursively even finding a duplicates and return false, but last call may still return true.
	// return true if it has duplicates!
	public bool InOrderCheckDuplicates(TreeNode<T> node)
	{
		if (node != null) return false;

		bool result = false;

		InOrderCheckDuplicates(node.Left);
		if (!Set.Add(node.Data))  // duplicates
		{
			result = true;
			return result;
		}
		InOrderCheckDuplicates(node.Right);

		return result;
	}

	// dictionary list all values and their appearance count
	public void InOrderFindDuplicates(TreeNode<T> node)
	{
		if (node != null)
		{
			InOrderFindDuplicates(node.Left);
			if (!Dic.ContainsKey(node.Data))  // duplicates
			{
				Dic[node.Data] = 1;
			}
			else
			{
				Dic[node.Data]++;
			}
			InOrderFindDuplicates(node.Right);
		}
	}

	public void PostOrder(TreeNode<T> node)
	{
		if (node == null) return;
		PostOrder(node.Left);
		PostOrder(node.Right);
		Visit(node);
	}

	private void Visit(TreeNode<T> node)
	{
		Console.Write($"{node.Data} ");
	}
}

public class BFS<T>  //breath first search, queue while
{
	Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

	public void Traversal(TreeNode<T> root)
	{
		if (root != null)
		{
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				TreeNode<T> node = queue.Dequeue();

				Console.Write($"{node.Data} ");

				if (node.Left != null)
				{
					queue.Enqueue(node.Left);
				}

				if (node.Right != null)
				{
					queue.Enqueue(node.Right);
				}
			}
		}
	}
}
