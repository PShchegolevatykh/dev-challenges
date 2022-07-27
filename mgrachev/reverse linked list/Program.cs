/* Reverse Linked List

Given the head of a singly linked list, reverse the list, and return the reversed list.

Example:
Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]
*/


var node1 = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
Solution.PrintNodes(node1);

var reversed = Solution.ReverseLinkedList(node1);
Solution.PrintNodes(reversed);

public class Node
{
    public Node Next { get; set;}
    public int Value { get; set; }

    public Node (int value)
    { 
        this.Value = value;
    }

    public Node(int value, Node next) : this(value)
    {
        this.Next = next;
    }
}

public class Solution
{
    public static Node ReverseLinkedList(Node node)
    {
        if (node == null) return null;
        
        Node prev = null;
        Node cur = node;
        while (cur != null)
        {
            var memoized = cur.Next;

            cur.Next = prev;

            prev = cur;
            cur = memoized; 
        }
        return prev;
    }


    public static void PrintNodes(Node node)
    {
        while (node != null)
        {
            Console.Write("{0}{1}", node.Value, node.Next != null ? " -> " : "");
            node = node.Next;
        }
        Console.WriteLine();
    }
}