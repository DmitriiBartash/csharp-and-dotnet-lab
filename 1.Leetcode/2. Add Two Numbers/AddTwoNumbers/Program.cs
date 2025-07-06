namespace AddTwoNumbers
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public class Solution
    {
        public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            var dummy = new ListNode();
            var current = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                carry = sum / 10;

                current.next = new ListNode(sum % 10);
                current = current.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            return dummy.next;
        }
    }

    // Tests
    class Program
    {
        static void Main()
        {
            var l1 = CreateList([2, 4, 3]);  // 342
            var l2 = CreateList([5, 6, 4]);  // 465

            var result = Solution.AddTwoNumbers(l1, l2);  // Expected result: 807 → [7, 0, 8]
            PrintList(result);  // Output: 7 - 0 - 8
        }

        static ListNode CreateList(int[] values)
        {
            var dummy = new ListNode();
            var current = dummy;
            foreach (var val in values)
            {
                current.next = new ListNode(val);
                current = current.next;
            }
            return dummy.next!;
        }

        static void PrintList(ListNode? node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null) Console.Write(" - ");
                node = node.next;
            }
            Console.WriteLine();
        }
    }
}



// Start (before refactoring)
//public class Solution
//{
//    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
//    {
//        int carry = 0;
//        ListNode listNode = new ListNode();
//        ListNode current = listNode;

//        while (l1 != null || l2 != null || carry != 0)
//        {
//            int x = (l1 != null) ? l1.val : 0;
//            int y = (l2 != null) ? l2.val : 0;

//            int sum = x + y + carry;
//            carry = sum / 10;

//            current.next = new ListNode(sum % 10);
//            current = current.next;

//            if (l1 != null) l1 = l1.next;
//            if (l2 != null) l2 = l2.next;
//        }

//        return listNode.next;
//    }
//}