namespace DevChallengesSolution;

public class BinaryTree
{
    // We need to traverse to very left and very right nodes of the tree until we reach the leaf
    // in every node we need to swap position of each sub tree. Left node will become right and vice versa.
    // To traverse to very left and very right nodes we can use postorder traversal.
    // In this case, at first we'll go to left and
    // swap nodes and then we'll go to right and do the same thing.
    // At the end we'll swap nodes in the root and this will solve the problem.
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
        {
            return root;
        }

        // use postorder traversal 
        // go to left
        InvertTree(root.left);

        // go to right
        InvertTree(root.right);

        // swap position of left and right subtrees
        var tempLeft = root.left;
        var tempRight = root.right;
        root.left = tempRight;
        root.right = tempLeft;

        return root;
    }
}

public class TreeNode
{
    public int val { get; set; }

    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public override string ToString()
    {
        return $"{val}";
    }
}