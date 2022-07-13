using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycledLinkedList
{
    public class CycledLinkedListSolution
    {
        public bool HasCycle(ListNode head)
        {
            if (head is null)
            {
                return false;
            }

            Dictionary<ListNode, int> occurrencesDictionary = new Dictionary<ListNode, int>();
            while (head.next != null)
            {
                if (occurrencesDictionary.ContainsKey(head))
                {
                    return true;
                }

                occurrencesDictionary.Add(head, 1);
                head = head.next;
            }

            return false;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val)
        {
            this.val = val;
            next = null;
        }
    }
}
