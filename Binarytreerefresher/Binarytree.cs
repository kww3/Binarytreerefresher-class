using Binarytreerefresher;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binarytreerefresher
{
    public class Node
    {   public int data;
        public Node left;
        public Node right;
        public Node parent;
    }
    public class Binarytree
    {
        public Node head;
        int value = 1;

        public void InOrder_Tree_Walk(Node x)
        {
            if (x != null)
            {
                InOrder_Tree_Walk(x.left);
                Console.WriteLine(x.data);
                InOrder_Tree_Walk(x.right);
            }
        }

        public int Tree_Height(Node x)
        {
            while (x.right != null)
            {
                x = x.right;
                value++;
                Tree_Height(x);
            }
            while (x.left != null)
            {
                x = x.left;
                value++;
                Tree_Height(x);
            }
            return value;
        }

        public Node Search_Node(Node x, int key)
        {
            if (x.data == key || x == null)
                return x;
            if (key < x.data)
                return Search_Node(x.left, key);
            else
                return Search_Node(x.right, key);
        }


        public void Add_Node(Node x, int y)
        {
            if (head == null)
            {
                head = new Node();
                head.data = y;
                return;
            }
            Node temp = new Node();
            temp = head;

            if (temp == null)
                Console.WriteLine("Node not found.");
            
            while (temp != null)
            {
                if (y < temp.data)
                {
                    if (temp.left == null)
                        break;
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                        break;
                    temp = temp.right;
                }
            }

            if (y < temp.data && temp.left == null) // Once you get there.
            {
                temp.left = new Node();
                temp.left.parent = temp;
                temp = temp.left;
                temp.data = y;
                return;
            }
            if (y > temp.data && temp.right == null)
            {
                temp.right = new Node();
                temp.right.parent = temp;
                temp = temp.right;
                temp.data = y;
                return;
            }
        }
        public Node Delete_Node(int key)
        {
            Node temp = Search_Node(head, key);
            if (temp == null)
                Console.WriteLine("Node not found.");

            if (temp.left == null && temp.right == null) // No children
            {
                if (temp.parent.left == temp)
                    temp.parent.left = null;
                else
                    temp.parent.right = null;
            }
            else if (temp.left != null && temp.right == null) // One child, left
            {
                temp.parent.left = temp.left;
                temp = temp.left; // sets temp to the nodewhich replaced the old one.
            }
            else if (temp.left == null && temp.right != null) // One child, right
            {
                temp.parent.left = temp.right;
                temp = temp.right; // sets temp to the nodewhich replaced the old one.
            }
            else // Two children
            {
                Node successor = MinValueNode(temp.right);
                int successorData = successor.data;
                Delete_Node(successorData);
                temp.data = successorData;
            } // Why not replace 15 with 13? Its b/c we assume we want to change as little of tree as possible.
            return temp;
        }
        public Node MinValueNode(Node x)
        {
            Node current = x;
            while (current.left != null)
                current = current.left;
            return current;
        }
        public Node MaxValueNode(Node x)
        {
            Node current = x;
            while (current.right != null)
                current = current.right;
            return current;
        }
    }
}
public class Program
{
    static void Main()
    {
        Node x = new Node();
        int test_1 = 5;
        int test_2 = 10;
        int test_3 = 2;
        Binarytree tree = new Binarytree();
        tree.Add_Node(x, 6);
        tree.Add_Node(x, 10);
        tree.Add_Node(x, 4);
        tree.Add_Node(x, 5);
        tree.Add_Node(x, 15);
        tree.Add_Node(x, 1);
        tree.Add_Node(x, 3);
        tree.Add_Node(x, 13);
        tree.Add_Node(x, 18);
        tree.Add_Node(x, 16);
        tree.Add_Node(x, 17);
        tree.Add_Node(x, 12);

        tree.Tree_Height(tree.head);
        tree.InOrder_Tree_Walk(tree.head);

        tree.Delete_Node(3); // running this will break line 149 ; comment out to test other caes.
        tree.Delete_Node(1); // One child, right
        tree.Delete_Node(13); //One child, left
        tree.Delete_Node(15); // Both children
        tree.Delete_Node(4); // both children 
        //tree.Delete_Node(3); // no  // running this and 180 will also cause nullref excep to search function.
    }
}

