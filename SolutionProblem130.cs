using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SolutionProblem130
    {

        public static void Main(string[] args)
        {

            char[] list1 = { 'O'};
            char[][] board = new char[][] { list1};
            /*char[] list1 = { 'X', 'O' };
            char[] list2 = { 'X', 'X' };
            char[][] board = new char[][]{ list1, list2 };*/
            Solve(board);

            int n = board.Length;
            int m = board[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void Solve(char[][] board)
        {
            int n = board.Length;
            int m = board[0].Length;
            // When m <= 2 and n <= 2, there are no 'inner layers', so there is no need of further processing.
            if (m > 2 || n > 2)
            {
                CheckExternalLayer(board);
                UpdateCharSymbols(board);
            }
        }

        /// <summary>
        /// Checks the external layer of the matrix, because when a position of this layer contains a 'O', it means that there is an
        /// entry point to inner positions of the matrix. Otherwise, if all the positions of the external layer contains a 'X', the 
        /// whole matrix is surrounded.
        /// </summary>
        /// <param name="board">Matrix that the problem has to modify.</param>
        public static void CheckExternalLayer(char[][] board)
        {
            int n = board.Length;
            int m = board[0].Length;
            int i = 0;
            int j = 0;

            while (j < m - 1)
            {
                LaunchDfsIfNecessary(board, i, j);
                j++;
            }

            while (i < n - 1)
            {
                LaunchDfsIfNecessary(board, i, j);
                i++;
            }

            while (j > 0)
            {
                LaunchDfsIfNecessary(board, i, j);
                j--;
            }

            while (i > 0)
            {
                LaunchDfsIfNecessary(board, i, j);
                i--;
            }
        }

        /// <summary>
        /// Replaces the '-' with 'O' and all other symbols with 'X'
        /// </summary>
        /// <param name="board">Matrix that the problem has to modify.</param>
        private static void UpdateCharSymbols(char[][] board)
        {
            int n = board.Length;
            int m = board[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i][j] == '-')
                    {
                        board[i][j] = 'O';
                    }
                    else
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }

        /// <summary>
        /// Launches a DFS whenever a 'O' is found in the current position of the matrix board.
        /// </summary>
        /// <param name="board">Matrix that the problem has to modify.</param>
        /// <param name="i">Row coordinate of the current position.</param>
        /// <param name="j">Column coordinate of the current position.</param>
        public static void LaunchDfsIfNecessary(char[][] board, int i, int j)
        {
            if (board[i][j] == 'O')
            {
                Dfs(board, i, j);
            }
        }

        /// <summary>
        /// DFS where the neighbords are verified and marked with a '-' when a 'O' is found. The endpoint of the search happens when
        /// there is no neighbor with a 'O' char.
        /// </summary>
        /// <param name="board">Matrix that the problem has to modify.</param>
        /// <param name="i">Row coordinate of the current position.</param>
        /// <param name="j">Column coordinate of the current position.</param>
        public static void Dfs(char[][] board, int i, int j)
        {
            int n = board.Length;
            int m = board[0].Length;
            board[i][j] = '-';

            if (i - 1 >= 0 && board[i - 1][j] == 'O')
            {
                Dfs(board, i - 1, j);
            }

            if (j - 1 >= 0 && board[i][j - 1] == 'O')
            {
                Dfs(board, i, j - 1);
            }

            if (i + 1 <= n - 1 && board[i + 1][j] == 'O')
            {
                Dfs(board, i + 1, j);
            }

            if (j + 1 <= m - 1 && board[i][j + 1] == 'O')
            {
                Dfs(board, i, j + 1);
            }

        }

    }
}
