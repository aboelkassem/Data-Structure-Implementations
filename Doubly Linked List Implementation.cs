using System.Collections.Generic;
using System;

class Solution
{
    static void Main(string[] args)
    {
	// do some examples code to test it
    }
}
public class DoublyLinkedList
{
    private class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int val)
        {
            this.data = val;
            this.next = null;
            this.prev = null;
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
            newNode.prev = temp;
        }
    }
    public void Insert_at_pos(int val, int pos)
    {
        Node newNode = new Node(val);
        // empty LinkedList
        if (head == null)
        {
            head = newNode;
            return;
        }
        if (pos == 0)
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
            return;
        }

        Node temp = head;

        for (int i = 0; i < pos && temp.next != null; i++)   // to get the node before target node , second condition to make sure it's still at range of linkedlist
        {
            temp = temp.next;
        }
        // special case if user entered position bigger than the range of linked list
        if (temp == null)
        {
            this.Append(val);   // append it to last of list,don't care about position
            return;
        }

        newNode.prev = temp.prev;
        temp.prev.next = newNode;
        temp.prev = newNode;
        newNode.next = temp;
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
        {
            return;
        }
        Node temp = head;

        if (head.data == val)
        {
            head = head.next;
            if (head != null)   // if the linked list have only one Node Skip this condition
            {
                head.prev = null;
            }
            return;
        }

        while (temp != null && temp.data != val)
        {
            temp = temp.next;
        }

        if (temp == null) // finished searched and don't found target Node
        {
            return;
        }
        else
        {
            temp.prev.next = temp.next;
            if (temp.next != null) // if the deleted element at the last of list Skip this condition
            {
                temp.next.prev = temp.prev; 
            }
        }
    }
    public void Remove_at_pos(int pos)
    {
        if (head == null)
        {
            return;
        }

        if (pos == 0)
        {
            head = head.next;
            if (head != null)   // if the linked list have only one Node Skip this condition
            {
                head.prev = null;
            }
            return;
        }
        else
        {
            Node temp = head;
            for (int i = 0; i < pos && temp.next != null; i++)   // to get the node before target node , second condition to make sure it's still at range of linkedlist
            {
                temp = temp.next;
            }
            if (temp == null) // finished searched and don't found target Node
            {
                return;
            }
            else
            {
                temp.prev.next = temp.next;
                if (temp.next != null) // if the deleted element at the last of list Skip this condition
                {
                    temp.next.prev = temp.prev;
                }
            }


        }

    }
    public void Reverse()
    {
        Node temp = head;
        // to get final Node
        while (temp.next != null)
        {
            temp = temp.next;
        }
        // return the list in reverse way
        while (temp != null)
        {
            temp = temp.prev;
        }
    }
    public void Reverse_Display()
    {
        Node temp = head;
        // to get final Node , store it in Temp
        while (temp.next != null)
        {
            temp = temp.next;
        }
        // return the list in reverse way
        while (temp != null)
        {
            Console.WriteLine(temp.data);
            temp = temp.prev;
        }
    }
}