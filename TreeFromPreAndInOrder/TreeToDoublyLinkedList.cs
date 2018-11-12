using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPractice
{
    class TreeToDoublyLinkedList
    {
        public Node Run2(Node root)
        {
            MakeDoubly(root);
            var leftMostNode = FindLeftOrRightMost(root, true);
            var rightMostNode = FindLeftOrRightMost(root, false);

            if (leftMostNode != null && rightMostNode != null)
            {
                leftMostNode.left = rightMostNode;
                rightMostNode.right = leftMostNode;
            }

            return leftMostNode;
        }

        private Node MakeDoubly(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var leftNode = MakeDoubly(node.left);

            // Set left.right to root and root.left to left.right
            if (leftNode != null)
            {
                if (leftNode.right != null)
                {
                    var leftRightMost = FindLeftOrRightMost(leftNode, false);
                    node.left = leftRightMost;
                    leftRightMost.right = node;
                }
                else
                {
                    leftNode.right = node;
                }
            }

            var rightNode = MakeDoubly(node.right);

            // Set right.left to root and root.right to right.left
            if (rightNode != null)
            {
                if (rightNode.left != null)
                {
                    var rightLeftMost = FindLeftOrRightMost(rightNode, true);
                    node.right = rightLeftMost;
                    rightLeftMost.left = node;
                }
                else
                {
                    rightNode.left = node;
                }
            }

            return node;
        }

        private Node FindLeftOrRightMost(Node node, bool isLeft)
        {
            if (node == null)
            {
                return null;
            }

            if (isLeft)
            {
                while (node.left != null)
                {
                    node = node.left;
                }
            }
            else
            {
                while (node.right != null)
                {
                    node = node.right;
                }
            }

            return node;
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }
        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }
}
