using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        // Testing
        Queue queue = new Queue();
        queue.Enqueue(6);
        queue.Enqueue(4);
        queue.Enqueue(9);
        queue.Enqueue(8);
        queue.Enqueue(5);

        Console.WriteLine(queue.Front());
        queue.Dequeue();
        queue.Dequeue();
        Console.WriteLine(queue.Front());

        if (queue.IsEmpty())
            Console.WriteLine("Queue is empty");
        else
            Console.WriteLine("Queue is Not empty");
    }
}
class Queue
{
    const int capacity = 100;
    int[] que = new int[capacity];
    int front = -1, rear = -1;

    public void Enqueue(int val)
    {
        if (IsFull())
            return;
        else if (IsEmpty())
            front = rear = 0;
        else
            rear = (rear + 1) % capacity; // (%)n is to start again from size , to use all memory of array


        que[rear] = val;
    }
    public void Dequeue()
    {
        if (IsEmpty())
            return;
        else if (front == rear)
            front = rear = -1;
        else
            front = (front + 1) % capacity; // (%)n is to start again from size , to use all memory of array
    }
    public int Front()
    {
        if (IsEmpty())
            return -1;  /// any number 
        else
            return que[front];
    }
    public bool IsEmpty()
    {
        if (front == -1 && rear == -1)
            return true;
        else 
            return false;
    }
    public bool IsFull()
    {
        if ((rear + 1) % capacity == front)
            return true;  // like a circular , if the next of array is the front so will be Full , (%)n is to start again from size , to use all memory of array
        else 
            return false;
    }
}