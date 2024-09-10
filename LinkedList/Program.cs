using System;
using System.Collections.Generic;


/*
Den länkade listan skall ha minst funktionerna
    AddElement
    RemoveLastElement
    samt propertyn Count

Lägg därefter till metoderna

    En indexer [].skall lämna ut värdet i det utpekade listelementet eller byta ut värdet.
    AddBeforeElement
    RemoveAfterElement
    RemoveAllAfterElement
    ToArray  - Returnerar en array av värdena i listan
    ToClonedArray - Returnerar en clonad array av värdena i listan
    SortLinkedList - sorterar listan i stigande eller fallande ordning
    En implementation av IEnumerable så att den länkade listans värden kan loopas igenom med ForEach

*/

internal class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedInts = new LinkedList<int>(new int[] { 3, 56, 78, 21, 34, 98, 45, 22 });

        // AddElement
        linkedInts.AddLast(3);

        // propertyn Count
        Console.WriteLine(linkedInts.Count());

        Print(linkedInts);
        int[] temp = new int[10];

        linkedInts.CopyTo(temp,0);

        linkedInts.AddFirst(99);
        Console.WriteLine("\nAfter adding 99 to the beginning:");
        Print(linkedInts);

        // RemoveLastElement
        linkedInts.RemoveLast();
        Console.WriteLine("\nAfter removing the last element:");
        Print(linkedInts);

        // AddBeforeElement
        LinkedListNode<int> node = linkedInts.Find(56);
        if (node != null)
        {
            linkedInts.AddBefore(node, 100);
        }
        Console.WriteLine("\nAfter adding 100 after 56:");
        Print(linkedInts);

        Print(RemoveAllAfterElement(linkedInts, 21));
    }

    // RemoveAllAfterElement
    public static LinkedList<int> RemoveAllAfterElement(LinkedList<int> linkedList, int value)
    {
        LinkedListNode<int> node = linkedList.Find(value);

        if (node != null && node.Next != null)
        {
            LinkedListNode<int> current = node.Next;

            while (current != null)
            {
                LinkedListNode<int> nextNode = current.Next;
                linkedList.Remove(current);
                current = nextNode;
            }
        }
        return linkedList;
    }

    public static int[] ToArray(LinkedList<int> linkedList)
    {
        int[] array = new int[linkedList.Count];

        int index = 0;
        foreach (int item in linkedList)
        {
            array[index++] = item;
        }

        return array;
    }

    public static void Print(LinkedList<int> linkedInts) 
    {
        foreach (int i in linkedInts)
            Console.WriteLine(i);
    }
}
