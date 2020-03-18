using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Solution
{
    static void Main(string[] args)
    {
        // do some code examples to test it
    }
}

public class BTNode
{
    public char value;
    public BTNode left = null;
    public BTNode right = null;

    public bool isLeaf()
    {
        return this.left == null && this.right == null;
    }

    public void print() // Pre Order Traversal implementation
    {
        Console.WriteLine(this.value);  // print head/first/parent value

        // Print left sub tree
        if (this.left != null)
            this.left.print();

        // Print Right sub tree
        if (this.right != null)
            this.right.print();
    }
}

public class BT
{
    public BTNode root = null;

    public void print()
    {
        this.root.print();
    }

    public bool isEmpty()
    {
        return root == null;
    }
}