using System;

namespace Number_of_Islands
{
    class Program
    {
        int row = 0;
        int column = 0;
        static void Main(string[] args)
        {
            var grid = new char[][]
            {
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' }
            };
            Program p = new Program();
            Console.WriteLine($"no of islands are = {p.NumIslands(grid)}");
        }

        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int count = 0;
            row = grid.Length;
            column = grid[0].Length;
            for(int i = 0; i < row; i ++)
            {
                for (int j = 0; j < column; j++)
                {
                    // when we find 1 i.e Island, perform DFS for all connecting Islands and Sink them in water.
                    if (grid[i][j] == '1')
                    {
                        Sink(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        void Sink(char[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= row || j >= column || grid[i][j] != '1') return;
            grid[i][j] = '0'; // update to 0 as the vertex is visited already.
            Sink(grid, i + 1, j); // go down
            Sink(grid, i - 1, j); // go up
            Sink(grid, i, j + 1); // go right
            Sink(grid, i, j - 1); // go left
        }
    }
}
