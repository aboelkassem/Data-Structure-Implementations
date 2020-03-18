using System;

class Solution
{
    static void Main(string[] args)
    {
        // testing it 
        LinkedList list = new LinkedList();
        list.Append(7);
        list.Append(3);
        list.Append(2);
        list.Append(6);
        list.Append(8);
        list.Append(10);
        list.Remove(10);
        list.Display();

    }
}

public class LinkedList
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int val)
        {
            data = val;
            next = null;
        }
    }
    Node head = null;

    public void Append(int val)
    {
        Node newNode = new Node(val);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }
    }
    public void Insert_at_pos(int val, int pos)
    {
        Node newNode = new Node(val);

        if (pos == 0)
        {
            newNode.next = head;
            head = newNode;
            return;
        }

        Node temp = head;

        for (int i = 0; i < pos - 1 && temp.next != null; i++)   // to get the node before target node , second condition to make sure it's still at range of linkedlist
        {
            temp = temp.next;
        }

        newNode.next = temp.next;
        temp.next = newNode;
    }
    public void Display()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.data);
            temp = temp.next;
        }
    }
    public void Remove(int val)
    {
        if (head == null)
            return;

        Node prev, temp;
        prev = temp = head;

        if (temp.data == val)
        {
            head = temp.next;
            return;
        }

        while (temp != null && temp.data != val)
        {
            prev = temp;
            temp = temp.next;
        }

        if (temp == null)
            return;
        else
            prev.next = temp.next;
    }
    public void Remove_at_pos(int pos)
    {
        if (head == null)
            return;

        if (pos == 0)
        {
            head = head.next;
        }
        else
        {
            Node temp = head;
            for (int i = 0; i < pos - 1 && temp.next != null; i++)   // to get the node before target node , second condition to make sure it's still at range of linkedlist
            {
                temp = temp.next;
            }
            if (temp.next == null) { return; } // if user entered pos out the range of linked list 

            temp.next = temp.next.next;
        }

    }
    public void Reverse()
    {
        if (head == null)
            return;

        Node prev, curr, next;
        prev = next = null;
        curr = head;

        while (curr != null)    // not reached to last element
        {
            // Links Controll
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        // move head to pointer on last element
        head = prev;
    }
}