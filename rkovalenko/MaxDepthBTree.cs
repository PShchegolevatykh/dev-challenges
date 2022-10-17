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
    public int MaxDepth(TreeNode root) {
        
        var maxDepth = 0;
        
        var currentNode = root;
        
        return GetLength(currentNode, maxDepth);
    }
    
    int GetLength(TreeNode head, int count)
    {
        if (head is not null)
        {
            ++count;
        }
        else
        {
            return count;
        }
        var leftLength = GetLength(head.left, count);
        var rightLength = GetLength(head.right, count);
        return leftLength > rightLength ? leftLength : rightLength;
    }
}