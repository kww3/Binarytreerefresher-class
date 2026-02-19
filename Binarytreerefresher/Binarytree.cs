using Binarytreerefresher;
using System;
using System.Collections.Generic;
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

        public Node Search_Node(Node x, int key)
        {
            if (key < x.data && x.left != null)
                while (x.left != null)
                { 
                    x = x.left;
                    Search_Node(x, key);
                }
            else if (key >= x.data && x.right != null)
                while (x.right != null)
                {
                    x = x.right;
                    Search_Node(x, key);
                }
            if (x.data == key)
                return x;

            return x;
        }

        public void Add_Node(Node x, int y)
        {
            if (head == null)
            {
                head = new Node();
                head.data = y;
            }
            Node temp = new Node();
            temp = head;

            temp = Search_Node(temp, y);

            if (y < temp.data && temp.left == null) // Once you get there.
            {
                temp.left = new Node();
                temp.left.parent = temp;
                temp = temp.left;
            }
            if (y > temp.data && temp.right == null)
            {
                temp.right = new Node();
                temp.right.parent = temp;
                temp = temp.right;
            }
            temp.data = y;
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
        tree.Add_Node(x, test_1);
        tree.Add_Node(x, test_2);
    }
}

