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

            HashSet<ListNode> occurrencesSet = new HashSet<ListNode>();
            while (head.next != null)
            {
                if (occurrencesSet.Contains(head))
                {
                    return true;
                }

                occurrencesSet.Add(head);
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
