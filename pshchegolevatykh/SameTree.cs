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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // only if both not null there is a reason to compare values
        if (p != null && q != null) {
            if (p.val != q.val) {
                return false;
            }
            // it's important here to compare left with left AND right with right
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        // if something was not null at the end then lengths were not the same
        return p == null && q == null;
    }
}