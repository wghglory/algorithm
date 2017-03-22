using System;

/*find max consecutive number sequence count*/
public class MaxSeqLenInTree
{

	public static int MaxSeqLen(TreeNode node)
	{
		if (node == null)
			return 0;
		else
			return MaxSeqLen(node, node.GetValue(), 1, 1);
	}

	// DFS
	// node value == parentnode value + 1
	private static int MaxSeqLen(TreeNode node, int parentValue, int currentSeqLen, int maxSeqLen)
	{
		if (node == null) return 0;

		if (node.GetValue() == parentValue + 1)
			currentSeqLen++;
		else
			currentSeqLen = 1;

		maxSeqLen = Math.Max(currentSeqLen, maxSeqLen);
		int leftMax = MaxSeqLen(node.LeftChild(), node.GetValue(), currentSeqLen, maxSeqLen);
		int rightMax = MaxSeqLen(node.RightChild(), node.GetValue(), currentSeqLen, maxSeqLen);

		return Math.Max(maxSeqLen, Math.Max(leftMax, rightMax));
	}

	public static void Main(string[] args)
	{

		//		     3
		//			/ \
		//		   5   2
		//        / \  / \
		//	     0	6  4  1
		//		/   /   \
		//     9   7	 8
		TreeNode n0 = new TreeNode(0);
		TreeNode n1 = new TreeNode(1);
		TreeNode n2 = new TreeNode(2);
		TreeNode n3 = new TreeNode(3);
		TreeNode n4 = new TreeNode(4);
		TreeNode n5 = new TreeNode(5);
		TreeNode n6 = new TreeNode(6);
		TreeNode n7 = new TreeNode(7);
		TreeNode n8 = new TreeNode(8);
		TreeNode n9 = new TreeNode(9);

		n3.setLeftChild(n5);
		n3.setRightChild(n2);

		n5.setLeftChild(n0);
		n5.setRightChild(n6);

		n2.setLeftChild(n4);
		n2.setRightChild(n1);

		n0.setLeftChild(n9);

		n6.setLeftChild(n7);

		n4.setRightChild(n8);

		Console.WriteLine(MaxSeqLen(n3));  // 3: 5-6-7
	}

}


public class TreeNode
{
	private int Data;
	private TreeNode Left, Right;

	public TreeNode(int data)
	{
		this.Data = data;
	}

	public int GetValue()
	{
		return Data;
	}

	public TreeNode LeftChild()
	{
		return Left;
	}

	public TreeNode RightChild()
	{
		return Right;
	}

	public void setLeftChild(TreeNode node)
	{
		Left = node;
	}

	public void setRightChild(TreeNode node)
	{
		Right = node;
	}
}
