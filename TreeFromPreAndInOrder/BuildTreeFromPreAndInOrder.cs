using FacebookPractice.DataStructures;
using System;
using System.Collections.Generic;

namespace FacebookPractice
{
    class BuildTreeFromPreAndInOrder
    {
        public Tuple<TreeNode<int>, List<int>> Run(List<int> preOrder, List<int> inOrder)
        {
            if (inOrder == null)
            {
                return new Tuple<TreeNode<int>, List<int>>(null, preOrder);
            }

            var root = new TreeNode<int>(preOrder[0]);
            preOrder = preOrder.GetRange(1, preOrder.Count - 1);

            var rootIndex = inOrder.IndexOf(root.Value);
            var leftTree = rootIndex > 0 ? inOrder.GetRange(0, rootIndex) : null;
            var rightTree = rootIndex != inOrder.Count - 1 ? inOrder.GetRange(rootIndex + 1, inOrder.Count - rootIndex - 1) : null;

            var leftResult = Run(preOrder, leftTree);
            root.Left = leftResult.Item1;
            preOrder = leftResult.Item2;

            var rightResult = Run(preOrder, rightTree);
            root.Right = rightResult.Item1;
            preOrder = rightResult.Item2;

            return new Tuple<TreeNode<int>, List<int>>(root, preOrder);
        }
    }
}
