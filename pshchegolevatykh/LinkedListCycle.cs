namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var givenList = new ListNode(5);
            InsertToTail(givenList, 6);
            InsertToTail(givenList, 7);
            InsertToHead(ref givenList, 8);
            InsertToHead(ref givenList, 9);
            InsertAfter(givenList.next, 11);
            DeleteFirst(ref givenList);

            bool hasCycle = HasCycle(givenList);
            Console.WriteLine($"Given list has cycle? {hasCycle}");
            Console.WriteLine("Okay let's make one.");
            givenList.next.next.next = givenList.next;
            hasCycle = HasCycle(givenList);
            Console.WriteLine($"Given list has cycle? {hasCycle}");
        }

        public static void InsertToTail(ListNode head, int itemToInsert)
        {
            while (head.next != null)
            {
                head = head.next;
            }

            head.next = new ListNode(itemToInsert);
        }

        public static void InsertAfter(ListNode givenNode, int itemToInsert)
        {
            if (givenNode == null)
            {
                return;
            }

            ListNode newNode = new ListNode(itemToInsert);
            newNode.next = givenNode.next;
            givenNode.next = newNode;
        }

        public static void DeleteFirst(ref ListNode head)
        {
            if (head != null)
            {
                head = head.next;
            }
        }

        public static void InsertToHead(ref ListNode head, int itemToInsert)
        {
            var newHead = new ListNode(itemToInsert);
            newHead.next = head;
            head = newHead;
        }

        public static bool HasCycle(ListNode head)
        {
            var visitedNodes = new List<ListNode>();

            while(head != null)
            {
                if (visitedNodes.Contains(head))
                {
                    return true;
                } else
                {
                    visitedNodes.Add(head);
                }

                head = head.next;
            }

            return false;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}