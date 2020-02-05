Linked lists and ListNode can be confusing if you've never done it. After the solution I've included what you can paste into Visual Studio to see what's required for testing.
```
public class Solution
{
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {

        //nodes can be deceiving if you think about them like other variables. In this case,
        //its easier to think about these two variables as pointers or node locations.
        //the nodes already exist, we are just rewriting their 'next' location data, and then reading
        //the full list from the beginning. constructedList is going to hang out at the start of the
        //linked list until it's assembled, then we will read it from that node.
        //linkBuilder is the pointer we are going to use to iterate and rewrite the next location data.

        ListNode constructedList = new ListNode(0);

        //they need to start at the same spot
        ListNode linkBuilder = constructedList;

        //we want to continue assessing the nodes until we reach the end of both lists
        while (l1 != null && l2 != null)
        {
            //find which of the two nodes has a smaller value, and set that as the next node location
            if (l1.val < l2.val)
            {
                //we write that new next location with linkBuilder
                linkBuilder.next = l1;

                //and then set the current node of l1 to the next node in the list because we want
                //to look at the next node on our next pass through the while-loop
                l1 = l1.next;
            }
            else
            {
                linkBuilder.next = l2;
                l2 = l2.next;
            }

            //once we have added the smaller node, we need to move our linkBuilder to that new node
            //so it can compare the next two to it. Otherwise, we will just overwrite the 'next' 
            //location data of the node we are currently on.
            linkBuilder = linkBuilder.next;
        }

        //the while loop has finished, meaning both linked lists have reached the end.
        //the final value has not been added, however. Add whichever list has a value.
        if (l1 != null)
        {
            linkBuilder.next = l1;
        }
        else
        {
            linkBuilder.next = l2;
        }

        //now that all of the 'next' location links have been established we can return the 
        //chain of nodes, starting from the beginning, right where we left our pointer from the
        //start to hang out. We take the next value because we started with an added 0 value.
        //we did that in the first place because we needed to add something after it, and it could
        //have been from either list.

        return constructedList.next;
    }
}
```

Here is the VS code you can use to test if you don't know how to set it up:
```
using System;
using System.Collections.Generic;

namespace <WHATEVER YOU HAVE NAMED THIS FILE>
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
            //solution code
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
```