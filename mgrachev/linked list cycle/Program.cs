/*
Linked List Cycle

Given head, the head of a linked list, determine if the linked list has a cycle in it.
There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.
*/

var node1 = new ListNode(0);
var node2 = new ListNode(1);
var node3 = new ListNode(5);

node1.Next = node2;
node2.Next = node3;
node3.Next = node1;

Console.WriteLine("Has cycle: {0}", new Solution().HasCycle(node1));

node3.Next = new ListNode(99);
Console.WriteLine("Has cycle: {0}", new Solution().HasCycle(node1));


public class ListNode 
{
      public int Val ;
      public ListNode Next {get;set;}
      public ListNode(int x) 
      {
          Val = x;
          Next = null;
      }
  }
 
public class Solution {
    
    public bool HasCycle(ListNode head)
    {
        return CheckHasCycleRecursive(head, head);
    }
    public bool CheckHasCycleRecursive(ListNode current, ListNode head) {
        if (current.Next == null)
        {
            return false;
        }
        return (current.Next == head ? true : CheckHasCycleRecursive(current.Next, head));
    }
}

