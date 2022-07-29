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
        
        var currentNode = head;
        var list = new List<int>();
        while(currentNode is not null)
        {
            list.Add(currentNode.val);
            
            currentNode = currentNode.next;
        }
        
        currentNode = head;
        int i = 0;
        var length = list.Count;
        while(currentNode is not null)
        {
            currentNode.val = list[length - i++ - 1];            
            currentNode = currentNode.next;
        }
        
        
        return head;
   
    }
}