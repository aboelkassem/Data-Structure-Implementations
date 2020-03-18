using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
class Node
{
    public int date;
    public Node left;
    public Node right;

    public Node(int value)
    {
        this.date = value;
        this.left = null;
        this.right = null;
    }
}

class BST
{
    Node root = null;   // empty BST

    private void AddHelper(Node temp, int value) // Private method with recursion
    {
        if (value <= temp.date)
        {
            if (temp.left == null)
            {
                temp.left = new Node(value);
            }
            else
            {
                AddHelper(temp.left, value);
            }
        }
        else
        {
            if (temp.right == null)
            {
                temp.right = new Node(value);
            }
            else
            {
                AddHelper(temp.right, value);
            }
        }
    }
    private int GetMaxHelper(Node temp)           // Private method with recursion
    {
        if (temp.right == null)
        {
            return temp.date;
        }
        else
        {
            return GetMaxHelper(temp.right);
        }
    }
    private int GetMinHelper(Node temp)           // Private method with recursion
    {
        if (temp.left == null)
        {
            return temp.date;
        }
        else
        {
            return GetMaxHelper(temp.left);
        }
    }
    private int GetHeightHelper(Node temp)        // Private method with recursion
    {
        if (temp == null)
        {
            return -1;	// height of empty subtree , after the leaf node
        }

        int Left_SubTree = GetHeightHelper(temp.left);
        int Right_SubTree = GetHeightHelper(temp.right);

        return 1 + Math.Max(Left_SubTree, Right_SubTree); // apply returning recursive on every node from empty node ==> leaf ==> parent tree ==> ....etc head
    }
    private Node RemoveHelper(Node root, int data)        // Private method with recursion
    {
        if (root == null)
        {
            return root;    // empty tree
        }
        else if (data < root.date)  // searching for element in BT conditions
        {
            root.left = RemoveHelper(root.left, data);
        }
        else if (data > root.date)  // searching for element in BT conditions
        {
            root.right = RemoveHelper(root.right, data);
        }
        else
        {
            if (root.left == null)   // has only one child or no children
            {
                return root.right;
                //Node ReturnedNodeToPerent = root.right;
                //return ReturnedNodeToPerent;
            }
            else if (root.right == null) // has only one child or no children
            {
                return root.left;
                //Node ReturnedNodeToPerent = root.left;
                //return ReturnedNodeToPerent;
            }
            else   // has Two children 
            {
                // for doing to left child
                int maxValue = this.GetMaxHelper(root.left);
                root.date = maxValue;
                root.left = RemoveHelper(root.left, maxValue);

                //// for doing to right child
                //int minValue = this.GetMinHelper(root.right);
                //root.date = minValue;
                //root.right = RemoveHelper(root.right, minValue); 
                
            }
        }
        return root;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    public void Add(int value)
    {
        if (root == null)
        {
            root = new Node(value);
        }
        else
        {
            AddHelper(root, value); // method to search which place on BTS conditions to put the newNode with recursion
        }
    }
    public int GetMax()
    {
        return GetMaxHelper(root);
    }
    public int GetMin()
    {
        return GetMinHelper(root);
    }
    public int GetHeight()
    {
        if (root == null)
        {
            return -1;
        }
        else
        {
            return GetHeightHelper(root);
        }
    }
    public void Display_LevelOrder()
    {
        if (root == null) { return; }

        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            Node current = q.Peek();
            q.Dequeue();

            Console.WriteLine(current.date);

            if (current.left != null) { q.Enqueue(current.left); }
            if (current.right != null) { q.Enqueue(current.right); }
        }
    }
    public void Remove(int data)
    {
        root = RemoveHelper(root, data);    // return a node to a root/parent that will linked to
    }
}


class Solution
{
    static void Main(string[] args)
    {
        // Testing
        BST sT = new BST();
        sT.Add(8);
        sT.Add(5);
        sT.Add(13);
        sT.Add(3);
        sT.Add(7);
        sT.Add(10);
        sT.Add(15);
        sT.Remove(15);
        sT.Display_LevelOrder();
        Console.WriteLine("Max Number of tree = {0}", sT.GetMax());
        Console.WriteLine("Min Number of tree = {0}", sT.GetMin());
        Console.WriteLine("Hight of tree = {0}", sT.GetHeight());
    }
}
/*
 ====================================> Add Method with loop <========================
  public void add(int value)
    {
        Node newNode  = new Node();
        newNode.date  = value;
        newNode.left  = null;
        newNode.right = null;

        if (root == null)
        {
            root = newNode;
            return;
        }

        Node temp = root; // equal Root ,to search for suitable place to Put newNode in BST ... in BST built conditions 
        Node parent = null;

        while (temp != null)
        {
            parent = temp;
            if (value <= temp.date) // based on BST condition the Node will go to Left
            {
                temp = temp.left;
            }
            else                   // based on BST condition the Node will go to Right
            {
                temp = temp.right;
            }
        }

        if (value <= parent.date)
        {
            parent.left = newNode;
        }
        else
        {
            parent.right = newNode;
        }
    }
    ================================================> Min/Max with Loop <==================================
   public int getMax()
    {
        Node temp = root;
        while (temp.right != null)
        {
            temp = temp.right;
        }
        return temp.date;
    }
    public int getMin()
    {
        Node temp = root;
        while (temp.left != null)
        {
            temp = temp.left;
        }
        return temp.date;
    }
 */
