namespace MvnTruong.Algorithms;

public class NumIslandsAlgorithm
{
    public int NumIslands(char[][] grid)
    {
        var islandCount = 0;
        var nextIsland = NextIsland(grid, 0, 0);
        while (nextIsland != null)
        {
            islandCount += 1;

            // sink all connected pieces of land
            SinkIsland(ref grid, nextIsland.Value.r, nextIsland.Value.c);
            
            nextIsland = NextIsland(grid, nextIsland.Value.r, nextIsland.Value.c);
        }

        return islandCount;
    }

    private (int r, int c)? NextIsland(char[][] grid, int r0, int c0)
    {
        for (int c = c0; c < grid[0].Length; c += 1)
        {
            if (grid[r0][c] == '1')
                return (r0, c);
        }
        
        for (int r = r0 + 1; r < grid.Length; r += 1)
        {
            for (var c = 0; c < grid[0].Length; c += 1)
            {
                if (grid[r][c] == '1')
                    return (r, c);
            }
        }

        return null;
    }

    private void SinkIsland(ref char[][] grid, int r0, int c0)
    {
        grid[r0][c0] = '0';

        if (r0 - 1 >= 0 && grid[r0 - 1][c0] == '1')
            SinkIsland(ref grid, r0 - 1, c0);
            
        if (c0 - 1 >= 0 && grid[r0][c0 - 1] == '1')
            SinkIsland(ref grid, r0, c0 - 1);
        
        if (r0 + 1 < grid.Length && grid[r0 + 1][c0] == '1')
            SinkIsland(ref grid, r0 + 1, c0);
        
        if (c0 + 1 < grid[0].Length && grid[r0][c0 + 1] == '1')
            SinkIsland(ref grid, r0, c0 + 1);
    }
}
