using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static Stack<TreeNode> helperStack = new Stack<TreeNode>();
        static LinkListNode output = new LinkListNode();
        static List<int> listOutputForTest = new List<int>();

        static void Main(string[] args)
        {
            TreeNode input = CreateInputTest();

            FlatTraverseOfTreeList(input);

        }

        private static TreeNode CreateInputTest()
        {
            var input = new TreeNode(1);
            input.right = new TreeNode(2);
            input.right.right = new TreeNode(3);
            input.right.right.left = new TreeNode(14);
            input.right.right.left.right = new TreeNode(15);
            input.right.right.left.left = new TreeNode(16);
            input.right.right.right = new TreeNode(4);
            input.left = new TreeNode(5);
            input.left.right = new TreeNode(6);
            input.left.right.right = new TreeNode(7);
            input.left.right.left = new TreeNode(8);
            input.left.right.right.right = new TreeNode(9);
            input.left.right.right.left = new TreeNode(10);
            input.left.right.right.left.left = new TreeNode(12);
            input.left.right.right.left.right = new TreeNode(11);
            input.left.right.right.left.left.left = new TreeNode(13);
            input.left.right.right.left.left.right = new TreeNode(17);

            return input;
        }

        private static void FlatTraverseOfTreeList(TreeNode input)
        {
            if (input.left == null && input.right == null)
            {
                if (helperStack.Count > 0)
                {
                    listOutputForTest.Add(input.value);
                    output.Add(input.value);
                    FlatTraverseOfTreeList(helperStack.Pop());
                }
                else
                {
                    listOutputForTest.Add(input.value);
                    output.Add(input.value);
                    return;
                }
            }

            else
            {
                listOutputForTest.Add(input.value);
                output.Add(input.value);

                if (input.left != null)
                {
                    if (input.right != null)
                        helperStack.Push(input.right);

                    FlatTraverseOfTreeList(input.left);
                    return;
                }

                if (input.right != null)
                    FlatTraverseOfTreeList(input.right);
                return;
            }


        }
    }
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { value = x; }
    }

    public class Node
    {
        public int value;
        public Node next;
        public Node(int val) { value = val; next = null; }
    }

    public class LinkListNode
    {
        public void Add(int val)
        {
            if (root == null)
            {
                var newItem = new Node(val);
                root = newItem;
                last = newItem;
            }
            else
            {
                Node newItem = new Node(val);
                last.next = newItem;
                last = newItem;
            }

        }

        public Node root;
        private Node last;

    }
}
