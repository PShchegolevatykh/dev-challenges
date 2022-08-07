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
        return RevertNode(root);
    }
    
    public TreeNode RevertNode(TreeNode node)
    {
        if(node is not null)
        {
            var temp = node.left;
            node.left = node.right;
            node.right = temp;
            
            RevertNode(node.left);
            RevertNode(node.right);
        }
        
        return node;
    }
}