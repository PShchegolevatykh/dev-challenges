using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Sum
{
    public class TreeNode
    {
        public int value { get; set; }
        public TreeNode left { get; set; }

        public TreeNode right { get; set; }

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.value = val;
            this.left = left;
            this.right = right;
        }

        public class MaximumDepthOfBinaryTree
        {
            public int MaxDepth(TreeNode root) =>
                MaxDepth(root, 0);

            private int MaxDepth(TreeNode node, int depth)
            {
                if (node is null)
                {
                    return depth;
                }

                // find max depth of left and right subtrees and return the largest value
                return Math.Max(MaxDepth(node.left, depth + 1), MaxDepth(node.right, depth + 1));
            }
        }
    }
}
