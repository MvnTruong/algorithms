namespace MvnTruong.Algorithms;

public class SolveNQueensBruteForce: ISolveNQueens
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var results = new List<IList<string>>();
        var board = new bool[n, n];
        var placed = new List<int>(n);

        var i = 0;
        var advancing = true;

        while (true)
        {
            if (advancing)
            {
                // Found a full solution
                if (placed.Count == n)
                {
                    results.Add(Render(board));
                    advancing = false;
                    continue;
                }

                // Ran out of squares -> must backtrack
                if (i >= n * n)
                {
                    advancing = false;
                    continue;
                }

                (int r, int c) = IndexToCoords(i, n);

                if (IsSafe(board, r, c))
                {
                    board[r, c] = true;
                    placed.Add(i);
                }

                i += 1;
            }
            else
            {
                if (placed.Count == 0)
                    return results; // search exhausted

                int last = placed[^1];
                placed.RemoveAt(placed.Count - 1);

                (int r, int c) = IndexToCoords(last, n);
                board[r, c] = false;

                i = last + 1;
                advancing = true;
            }
        }
    }

    private static (int r, int c) IndexToCoords(int i, int n)
    {
        int r = i / n;
        int c = i % n;
        return (r, c);
    }

    private static List<string> Render(bool[,] board)
    {
        int n = board.GetLength(0);
        var lines = new List<string>(n);

        for (var r = 0; r < n; r += 1)
        {
            var chars = new char[n];
            for (var c = 0; c < n; c += 1)
                chars[c] = board[r, c] ? 'Q' : '.';

            lines.Add(new string(chars));
        }

        return lines;
    }

    private static bool IsSafe(bool[,] board, int r0, int c0)
    {
        int n = board.GetLength(0);
        for (var r = 0; r < n; r += 1)
        {
            if (board[r, c0])
                return false;
        }

        for (var c = 0; c < n; c += 1)
        {
            if (board[r0, c])
                return false;
        }

        int du = Math.Min(r0, c0);
        for (int r = r0 - du, c = c0 - du; r < n && c < n; r += 1, c += 1)
        {
            if (board[r, c])
                return false;
        }
        
        int d2 = Math.Min(r0, n - 1 - c0);
        for (int r = r0 - d2, c = c0 + d2; r < n && c >= 0; r += 1, c -= 1)
        {
            if (board[r, c])
                return false;
        }
        
        return true;
    }
}