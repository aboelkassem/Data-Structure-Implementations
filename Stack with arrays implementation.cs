using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        Stack stk = new Stack();    // from my custom Class Stack
        stk.Push(5);
        stk.Push(7);
        stk.Push(9);
        while (!stk.IsEmpty())
        {
            Console.WriteLine(stk.Top());
            stk.Pop();
        }
        Console.WriteLine("=================================================");
        Stack<int> stack = new Stack<int>();    // built in Stack
        stack.Push(5);
        stack.Push(7);
        stack.Push(9);
        foreach (var s in stack)
        {
            Console.WriteLine(s);
        }

    }
}

class Stack
{
    int[] arr = new int[100];
    int top = -1;   // this make arr empty
    public void Push(int val)
    {
        if (top==99){return; } // to make sure that array not empty
        //top++;
        arr[++top] = val;
    }
    public int Pop()
    {
        if (IsEmpty()){return -1;}
        var tempRemoved = top;

        top--;
        return arr[tempRemoved];
    }
    public int Top()
    {
        if (IsEmpty()){return -1;}  // to make sure that array not empty
        return arr[top];
    }
    public bool IsEmpty()
    {
        return top == -1 ? true : false;
    }
}