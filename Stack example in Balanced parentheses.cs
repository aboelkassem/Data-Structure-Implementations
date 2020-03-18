// solve the problem How to know if this bracket's is balanced ex ({1+9}*2)+[5-2] ... to know must sure if last added bracket { has his closing } 
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        if (Balanced(s))
        {
            Console.WriteLine("Expression is balanced");
        }
        else
        {
            Console.WriteLine("Expression is Not balanced");
        }
    }
    public static bool Balanced(string exp)
    {
        Stack open_Brackets = new Stack();      // stack to store open brackets ordering
        for (int i = 0; i < exp.Length; i++)
        {
            if (exp[i]=='('|| exp[i] == '{' || exp[i] == '[')
            {
                open_Brackets.Push(exp[i]);
            }
            else if (exp[i] == ')' || exp[i] == '}' || exp[i] == ']')
            {
                if (open_Brackets.IsEmpty())
                {
                    return false;
                }
                else if (Pair(Convert.ToChar(open_Brackets.Top()),exp[i]) == false) 
                {
                    return false;
                }
                open_Brackets.Pop();
            }
        }
        if (open_Brackets.IsEmpty())
        {
            return true;
        }
        return false;
    }
    public static bool Pair(char open , char close)
    {
        if (open =='(' && close ==')'){return true;}
        else if (open == '{' && close == '}'){return true;}
        else if (open == '[' && close == ']'){return true;}
        return false;
    }
}
class Stack
{
    int[] arr = new int[100];
    int top = -1;   // this make arr empty
    public void Push(int val)
    {
        if (top==99){return; } // to make sure that array not empty
        top++;
        arr[top] = val;
    }
    public void Pop()
    {
        if (IsEmpty()){return;}
        top--;
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