/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode reversed = null;

        while (head != null)
        {
            if (reversed == null) // empty chain
            {
                reversed = new ListNode(head.val);
            }
            else // already have a chain
            {
                // remember previous chain
                var previousNodeChain = reversed;
                // new head is always last item
                reversed = new ListNode(head.val); 
                // set existing chain to new head
                reversed.next = previousNodeChain;
            }

            head = head.next;
        }

        return reversed;
    }
}