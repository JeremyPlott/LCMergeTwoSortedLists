using System;
using System.Collections.Generic;

namespace LCMergeTwoSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            ListNode mergedList = MergeTwoLists(l1, l2);

            while (mergedList != null)
            {
                Console.WriteLine(mergedList.val);
                mergedList = mergedList.next;
            }
 
            ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                ListNode constructedList = new ListNode(0);
                ListNode linkBuilder = constructedList;

                while (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        linkBuilder.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        linkBuilder.next = l2;
                        l2 = l2.next;
                    }

                    linkBuilder = linkBuilder.next;
                }

                if (l1 != null)
                {
                    linkBuilder.next = l1;
                }
                else
                {
                    linkBuilder.next = l2;
                }

                return constructedList.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
