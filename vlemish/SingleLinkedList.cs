namespace DevChallengesSolution;

public class SingleLinkedList
{
    // To reverse a linked list we need to traverse through all the nodes and change direction of it
    // so basically we need to update next's of all elements from pointing actual `next` element to pointing `previous` element.
    // To do it we can use temp variables to store previous and current node and then just make current.next to point to previous node.
    // Then we need to return `previous` variable which will hold reversed linked list structure 
    public ListNode ReverseLinkedList(ListNode head)
    {
        if (head is null || head.next is null)
        {
            return head;
        }

        ListNode current = head;
        ListNode previous = null;
        ListNode temp = null;
        while (current is not null)
        {
            // save current.next element to not to lose after repointing current.next to previous
            temp = current.next;
            current.next = previous;
            previous = current;
            current = temp;
        }

        return previous;
    }
}

public class ListNode
{
    public int val { get; set; }

    public ListNode next { get; set; }

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        return $"{val}";
    }
}