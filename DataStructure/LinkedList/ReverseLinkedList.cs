// reversing the linked list
// Time Complexity: O(n)
// Space Complexity: O(1)
using System;

public class LinkedList
{
	Node head;

	class Node
	{
		public int data;
		public Node next;
		public Node(int d)
		{
			data = d;
			next = null;
		}
	}

	/* iterative Function to reverse the linked list */
	Node reverse(Node node)
	{
		Node prev = null;
		Node current = node;
		Node next = null;
		while (current != null)
		{
			next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}
		node = prev;
		return node;
	}

	// A simple and tail recursive function to reverse
	// a linked list.  prev is passed as NULL initially.
	Node reverseUtil(Node curr, Node prev)
	{

		/* If last node mark it head*/
		if (curr.next == null)
		{
			head = curr;

			/* Update next to prev node */
			curr.next = prev;
			return null;
		}

		/* Save curr->next node for recursive call */
		Node next = curr.next;

		/* and update next ..*/
		curr.next = prev;

		reverseUtil(next, curr);
		return head;
	}

	// prints content of double linked list
	void printList(Node node)
	{
		while (node != null)
		{
			Console.Write(node.data + " ");
			node = node.next;
		}
	}

	public static void Main(string[] args)
	{
		LinkedList list = new LinkedList();
		list.head = new Node(85);
		list.head.next = new Node(15);
		list.head.next.next = new Node(4);
		list.head.next.next.next = new Node(20);

		Console.WriteLine("Given Linked list");
		list.printList(list.head);
		var head = list.reverse(list.head);
		Console.WriteLine("");
		Console.WriteLine("Reversed linked list ");
		list.printList(head);

		Console.WriteLine("\n\n===============================\n");

		LinkedList list2 = new LinkedList();
		list2.head = new Node(1);
		list2.head.next = new Node(2);
		list2.head.next.next = new Node(3);
		list2.head.next.next.next = new Node(4);
		list2.head.next.next.next.next = new Node(5);
		list2.head.next.next.next.next.next = new Node(6);
		list2.head.next.next.next.next.next.next = new Node(7);
		list2.head.next.next.next.next.next.next.next = new Node(8);

		Console.WriteLine("Given Linked list ");
		list2.printList(list2.head);
		Node res = list2.reverseUtil(list2.head, null);
		Console.WriteLine("");
		Console.WriteLine("Reversed linked list ");
		list2.printList(res);
	}
}
