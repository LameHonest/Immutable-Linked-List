using System;

public class Program
{
    public static void Main()
    {
        List<string> newList = new List<string>();
        newList.addNode("A");
        newList.addNode("B");
        newList.addNode("D");
        newList.addNode("D");

        Console.WriteLine("This list has: " + newList.getListCount().ToString() + " elements:");
        newList.showList();

        Console.WriteLine("Replacing element 3: D on C");
        newList.replaceNode(3, "C");
        Console.WriteLine("This list has: " + newList.getListCount().ToString() + " elements:");
        newList.showList();

        Console.WriteLine("Creating new list");
        List<string> newList2 = new List<string>();
        newList2.addNode("E");
        newList2.addNode("F");
        newList2.addNode("H");

        Console.WriteLine("This list has: " + newList2.getListCount().ToString() + " elements:");
        newList2.showList();

        Console.WriteLine("Merging two lists");
        newList.mergeTwoLists(newList2);

        Console.WriteLine("This list has: " + newList.getListCount().ToString() + " elements:");
        newList.showList();

        Console.WriteLine("Replacing last element: H on G");
        newList.replaceNode(7, "G");

        Console.WriteLine("This list has: " + newList.getListCount().ToString() + " elements:");
        newList.showList();
    }
}

class ListNode<T>
{
    public readonly T Value;
    public readonly ListNode<T> Next;

    public ListNode(T value, ListNode<T> next)
    {
        this.Value = value;
        this.Next = next;
    }
}

class List<T>
{
    private ListNode<T> head;

    public void addNode(T value)
    {
        if (head == null)
        {
            head = new ListNode<T>(value, null);
        }
        else
        {
            if (head.Next == null)
            {
                ListNode<T> nextNode = new ListNode<T>(value, null);
                head = new ListNode<T>(head.Value, nextNode);
            }
            else
            {
                ListNode<T> nextNodeHead = head;
                bool final = false, firstHead = false;
                while (true)
                {
                    if (final && firstHead)
                    {
                        head = new ListNode<T>(value, head);
                        break;
                    }
                    if (!firstHead)
                    {
                        nextNodeHead = head.Next.Next;
                        if (nextNodeHead == null)
                        {
                            final = true;
                        }
                        ListNode<T> buf = new ListNode<T>(head.Value, null);
                        head = new ListNode<T>(head.Next.Value, buf);
                        firstHead = true;
                    }
                    else
                    {
                        head = new ListNode<T>(nextNodeHead.Value, head);
                        nextNodeHead = nextNodeHead.Next;
                        if (nextNodeHead == null)
                        {
                            final = true;
                        }
                    }
                }
                firstHead = false;
                while (true)
                {
                    if (!firstHead)
                    {
                        ListNode<T> buf = new ListNode<T>(head.Value, null);
                        nextNodeHead = head.Next.Next;
                        head = new ListNode<T>(head.Next.Value, buf);
                        firstHead = true;
                    }
                    else
                    {
                        ListNode<T> buf = nextNodeHead;
                        nextNodeHead = nextNodeHead.Next;
                        head = new ListNode<T>(buf.Value, head);
                        if (nextNodeHead == null) break;

                    }
                }
            }
        }
    }

    public void replaceNode(int index, T value)
    {
        if (index <= this.getListCount())
        {
            bool firstHead = false;
            ListNode<T> nextNodeHead = head;
            for (int i = 1; i < index; i++)
            {
                if (!firstHead)
                {
                    nextNodeHead = head.Next.Next;
                    ListNode<T> buf = new ListNode<T>(head.Value, null);
                    head = new ListNode<T>(head.Next.Value, buf);
                    firstHead = true;
                }
                else
                {
                    head = new ListNode<T>(nextNodeHead.Value, head);
                    nextNodeHead = nextNodeHead.Next;
                }
            }
            if (!firstHead)
            {
                head = new ListNode<T>(value, head.Next);
                return;
            }
            ListNode<T> prevNode = nextNodeHead;
            nextNodeHead = head.Next;
            head = new ListNode<T>(value, prevNode);
            firstHead = false;
            while (true)
            {
                head = new ListNode<T>(nextNodeHead.Value, head);
                if (nextNodeHead.Next == null)
                {
                    break;
                }
                else
                {
                    nextNodeHead = nextNodeHead.Next;
                }
            }
        }
    }

    public int getListCount()
    {
        ListNode<T> step = head;
        int count = 0;
        while (step != null)
        {
            count++;
            step = step.Next;
        }
        return count;
    }

    public void mergeTwoLists(List<T> secondList)
    {
        ListNode<T> step = secondList.head;
        while (step != null)
        {
            this.addNode(step.Value);
            step = step.Next;
        }
    }
    public void showList()
    {
        ListNode<T> step = head;
        while (step != null)
        {
            T nodeValue = step.Value;
            Console.WriteLine(nodeValue);
            step = step.Next;
        }
    }


}