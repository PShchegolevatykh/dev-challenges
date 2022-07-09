namespace ConsoleApp1
{
    internal class Program
    {
        // Given the root of a binary tree, return its maximum depth.

        // A binary tree's maximum depth is the number of nodes along
        // the longest path from the root node down to the farthest leaf node.

        // Each node of the tree will have a root value and a list of references to other nodes
        // which are called child nodes.

        // A binary tree is a tree data structure in which each node has at most
        // two children, which are referred to as the left child and the right child.

        // preorder, inorder and postorder traversal recursively
        // preorder, inorder and postorder traversal iteratively

        // Pre-order traversal is to visit the root first
        // Then traverse the left subtree. Finally, traverse the right subtree.
        // 1. Visit Node
        // 2. Go to left-subtree
        // 3. Go to right-subtree

        // In-order traversal is to traverse the left subtree first.
        // Then visit the root. Finally, traverse the right subtree.
        // 1. Go to left-subtree
        // 2. Visit Node
        // 3. Go to right-subtree
        // In-norder Traversal of Binary Search Tree will always give you
        // Nodes in sorted manner.

        // Post-order traversal is to traverse the left subtree first.
        // Then traverse the right subtree. Finally, visit the root.
        // 1. Go to left-subtree
        // 2. Go to right-subtree
        // 3. Visit Node

        // Depth-First Search (DFS) Algorithm: It starts with the root node
        // and first visits all nodes of one branch as deep as possible of the chosen Node and before backtracking,
        // it visits all other branches in a similar fashion.

        // Breadth-First Search (BFS) Algorithm: It also starts from the root node
        // and visits all nodes of current depth before moving to the next depth
        // in the tree.

        static void InOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.left);
                Console.Write($"{root.val} ");
                InOrderTraversal(root.right);
            }
        }

        static void PreOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                Console.Write($"{root.val} ");
                PreOrderTraversal(root.left);
                PreOrderTraversal(root.right);
            }
        }

        static void PreOrderTraversalLoop(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any())
            {
                TreeNode node = stack.Pop();

                Console.Write($"{node.val} ");
                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
        }

        static void PostOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                PostOrderTraversal(root.left);
                PostOrderTraversal(root.right);
                Console.Write($"{root.val} ");
            }
        }

        static void LevelOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode> ();
            queue.Enqueue(root);

            while (queue.Any())
            {
                TreeNode node = queue.Dequeue();

                Console.Write($"{node.val} ");

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var maxLeft = MaxDepth(root.left);
            var maxRight = MaxDepth(root.right);
            return Math.Max(maxLeft, maxRight) + 1;
        }

        static void Main(string[] args)
        {
            var root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            Console.WriteLine("Pre-Order traversal");
            PreOrderTraversal(root);
            Console.WriteLine("\nPre-Order traversal in loop");
            PreOrderTraversalLoop(root);
            Console.WriteLine("\nIn-Order traversal");
            InOrderTraversal(root);
            Console.WriteLine("\nPost-Order traversal");
            PostOrderTraversal(root);
            Console.WriteLine("\nLevel-Order traversal (BFS)");
            LevelOrderTraversal(root);
            Console.WriteLine($"\nMax depth (height) = {MaxDepth(root)}");
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}