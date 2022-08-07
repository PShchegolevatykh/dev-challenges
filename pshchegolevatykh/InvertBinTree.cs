/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        // corner case
        if (root == null)
        {
            return null;
        }

        // use stack to traverse the tree in the loop
        // that's because I'm scared of recursion and don't have much
        // experience using it and understanding recursion is harder on my soft brain
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        
        while (stack.Any())
        {
            // take current tree node
            TreeNode node = stack.Pop();

            // I used OR because failed with AND
            // aparently they want to still invert even in case of NULL
            // on either side e.g. [1,2] becomes [1, null, 2]
            if (node.left != null || node.right != null)
            {
               // swap left and right node
               var tempNode = node.left;
               node.left = node.right;
               node.right = tempNode;
            }
            
            // continue with traversal until the end
            if (node.right != null)
            {
                stack.Push(node.right);
            }
            
            if (node.left != null)
            {
                stack.Push(node.left);
            }
        }
        
        // they ask you to return root, so here it is
        return root;
    }
}