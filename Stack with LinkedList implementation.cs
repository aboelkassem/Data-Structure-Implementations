using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        // create Object of Implementing class
        StackUsingLinkedlist stk = new StackUsingLinkedlist();

        // insert Stack value  
        stk.push(11);
        stk.push(22);
        stk.push(33);
        stk.push(44);

        // print Stack elements
        stk.display();

        // print Top element of Stack
        Console.Write("\nTop element is {0}\n", stk.peek());

        // Delete top element of Stack
        stk.pop();
        stk.pop();

        // print Stack elements  
        stk.display();

        // print Top element of Stack
        Console.Write("\nTop element is {0}\n", stk.peek());
    }
}

public class StackUsingLinkedlist
{

    // A linked list node  
    private class Node
    {
        // integer data  
        public int data;

        // reference variable Node type  
        public Node Next;

        public Node(int data)
        {
            this.data = data;
            this.Next = null;
        }
    }

    // create global top reference variable  
    Node top;

    // Constructor  
    public StackUsingLinkedlist()
    {
        this.top = null;
    }

    // Utility function to add  
    // an element x in the stack  
    // insert at the beginning  
    public void push(int x)
    {
        // create new node temp and allocate memory  
        Node newNode = new Node(x);

        // check if stack (heap) is full.  
        // Then inserting an element 
        // would lead to stack overflow  
        if (newNode == null)
        {
            Console.Write("\nHeap Overflow");
            return;
        }

        // put top reference into temp link  
        newNode.Next = top;

        // update top reference  
        top = newNode;
    }

    // Utility function to check if 
    // the stack is empty or not  
    public bool isEmpty()
    {
        return top == null;
    }

    // Utility function to return 
    // top element in a stack  
    public int peek()
    {
        // check for empty stack  
        if (!isEmpty())
        {
            return top.data;
        }
        else
        {
            Console.WriteLine("Stack is empty");
            return -1;
        }
    }

    // Utility function to pop top element from the stack  
    public void pop() // remove at the beginning  
    {
        // check for stack underflow  
        if (top == null)
        {
            Console.Write("\nStack Underflow");
            return;
        }

        // update the top pointer to  
        // point to the next node  
        top = (top).Next;
    }

    public void display()
    {
        // check for stack underflow  
        if (top == null)
        {
            Console.Write("\nStack Underflow");
            return;
        }
        else
        {
            Node temp = top;
            while (temp != null)
            {
                // print node data  
                Console.Write("{0}->", temp.data);

                // assign temp link to temp  
                temp = temp.Next;
            }
        }
    }
}