using LeetCode;

public class SolutionProblem129
{

    public static int SumNumbers(TreeNode root)
    {
        return Dfs(root, root.val, 0);
    }

    public static int Dfs(TreeNode node, int sumBranch, int accumulator)
    {
        // If node is a leaf, we are done 
        if (node.left == null && node.right == null)
        {
            return accumulator + sumBranch;
        }

        // If there is a left child, go left adding the left node value to the sum of the current branch
        if (node.left != null)
        {
            accumulator = Dfs(node.left, sumBranch*10 + node.left.val, accumulator);
        }
        // If there is a right child, go right adding the right node value to the sum of the current branch
        if (node.right != null)
        {
            accumulator = Dfs(node.right, sumBranch*10 + node.right.val, accumulator);
        }

        return accumulator;
    }

}