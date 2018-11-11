using System.Text;

namespace FacebookPractice
{
    class AreTreeEqual
    {
        public bool Run(TreeNode p, TreeNode q)
        {
            var pInOrder = DoInOrder(p, new StringBuilder());
            var qInOrder = DoInOrder(q, new StringBuilder());

            return p.ToString().Equals(q.ToString());
        }

        private StringBuilder DoInOrder(TreeNode p, StringBuilder inOrder)
        {
            if (p == null)
            {
                return inOrder ?? new StringBuilder();
            }

            inOrder = DoInOrder(p.left, inOrder);
            var current = inOrder.Append(p.val);
            inOrder = DoInOrder(p.right, inOrder);

            return inOrder;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
