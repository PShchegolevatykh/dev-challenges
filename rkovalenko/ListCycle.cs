public class Solution {
    public bool HasCycle(ListNode head) {
        
        if(head is null || head.next is null)
        {
            return false;
        }
        
        var slow = head;
        var fast = head.next;
        
        while(slow is not null && fast.next is not null && fast.next.next is not null)
        {
            if(slow == fast)
            {
                return true;
            }
            
            slow = slow.next;

            fast = fast.next.next;
            
        }
        
        return false;
    }
}