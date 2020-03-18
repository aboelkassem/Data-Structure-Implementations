using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        Queue q = new Queue();
        q.enqueue(10);
        q.enqueue(20);
        q.dequeue();
        q.dequeue();
        q.enqueue(30);
        q.enqueue(40);
        q.enqueue(50);
        q.dequeue();
        Console.WriteLine("Queue Front : " + q.front.data);
        Console.WriteLine("Queue Rear : " + q.rear.data);
    }
}

// A linked list (LL) node to 
// store a queue entry 
class Node
{
    public int data;
    public Node next;

    // constructor to create 
    // a new linked list node 
    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

// A class to represent a queue The queue, 
// front stores the front node of LL and 
// rear stores the last node of LL 
class Queue
{
    public Node front, rear;

    public Queue()
    {
        this.front = this.rear = null;
    }

    // Method to add an data to the queue. 
    public void enqueue(int data)
    {
        // Create a new LL node 
        Node newNode = new Node(data);

        // If queue is empty, then new 
        // node is front and rear both 
        if (this.rear == null)
        {
            this.front = this.rear = newNode;
            return;
        }

        // Add the new node at the 
        // end of queue and change rear 
        this.rear.next = newNode;
        this.rear = newNode;
    }

    // Method to remove an data from queue. 
    public void dequeue()
    {
        // If queue is empty, return NULL. 
        if (this.front == null)
            return;

        // Store previous front and 
        // move front one node ahead 
        this.front = this.front.next;

        // If front becomes NULL, 
        // then change rear also as NULL 
        if (this.front == null)
            this.rear = null;
    }
}
