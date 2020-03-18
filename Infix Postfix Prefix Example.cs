using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        Console.WriteLine("Infix = " +"(3+2)+7/2*((7+3)*2)");
        string infixExpression = "(3+2)+7/2*((7+3)*2)";
        Console.WriteLine("Postfix = "+Infix_To_Postfix(infixExpression));
        string postfixEpxression = Infix_To_Postfix(infixExpression);
        Console.WriteLine("Value Of Postfix = "+ Postfix_Evaluate(postfixEpxression));
    }
    public static string Infix_To_Postfix(string exp)
    {
        Stack<char> stk = new Stack<char>();
        string output = "";
        //-------------------------------------
        for (int i = 0; i < exp.Length; i++)
        {
            if (exp[i] == ' ') continue;

            if (Char.IsNumber(exp[i]) || Char.IsLetter(exp[i]))
            {
                output += exp[i];
            }
            else if (exp[i] == '(')
            {
                stk.Push('(');
            }
            else if (exp[i]==')')
            {
                while (stk.Peek() != '(')
                {
                    output += stk.Peek();
                    stk.Pop();
                }
                stk.Pop(); // remove the '('
            }
            else
            {
                while (stk.Count !=0 && Priority(exp[i]) <= Priority(stk.Peek()))   // to check if Priority of coming operator is equal or less than Top operator in Stack , put is to output string and remove from stack and check again ...
                {
                    output += stk.Peek();
                    stk.Pop();
                }
                stk.Push(exp[i]);
            }
        }
        while (stk.Count != 0)
        {
            output += stk.Peek();
            stk.Pop();
        }
        return output;
    }
    public static int Priority(char c)
    {
        if (c == '-'|| c == '+'){ return 1;}
        else if (c == '*' || c == '/') { return 2; }
        else if (c == '^') { return 3; }
        else { return 0; }
    }

    //-------------------------------------------- Evaluate the Postfix/Prefix -------------------------------------
    public static float Postfix_Evaluate(string exp)
    {
        Stack<float> stk = new Stack<float>();
        for (int i = 0; i < exp.Length; i++)
        {
            if (Char.IsNumber(exp[i]))
            {
                stk.Push(exp[i]-'0');   // to get the Char as Number , multi it from 0 ASCII = 48 ==> ex num 2 , 50 - 48 = 2 so ==> '2'-'0' = 2 
            }
            else
            {
                float operand2 = stk.Peek();
                stk.Pop();

                float operand1 = stk.Peek();
                stk.Pop();

                float result = MathOperation(operand1, operand2, exp[i]);
                stk.Push(result);
            }
        }
        return stk.Peek(); // the value of expression was the latest value of stack
    }
    public static float MathOperation(float op1 , float op2 , char Operator)
    {
        if (Operator == '+') { return op1 + op2; }
        else if (Operator == '-') { return op1 - op2; }
        else if (Operator == '*') { return op1 * op2; }
        else if (Operator == '/') { return op1 / op2; }
        else { return 0; }
    }
}
/* ===============================> Algorithm steps <===================================
 ***** Infix to PostFix
 1- Create Empty Stack & Empty string for output
 2- Loop on the infix expression
        - if it's a digit or number then add it to the Output
        - if it's [ ( ] then add it to the stack
        - if it's [ ) ] then pop from stack to Output until reach to [ ( ]
        - if it's an operator [ +,*,/,- ] then pop from stack until you can push it to the stack (if the priority of operator is greater than existing in stack)
 3- If the stack is not empty then pop to the output
 4- Print the Output
 
 ***** Evaluate th PostFix expression
 1- Create empty stack
 2- loop on the postfix expression
        - every number will push to stack
        - if an operator put the stack top = Second Operand, the next top = First Operand
        - evaluate the first and second operand within operator type and the result will push to stack ==> [first operand] [operator] [second operand] = result
        - repeat until stack is empty and final answer will be only in the stack
 3- print top of stack as final answer
*/