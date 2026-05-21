namespace MvnTruong.Algorithms;

public class SolveNQueensClever: ISolveNQueens
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        List<IList<string>> results = [];
        var board = new bool[n, n];

        PlaceRow(0, board, n, results);
        return results;
    }

    private static void PlaceRow(int r, bool[,] board, int n, List<IList<string>> results)
    {
        if (r == n)
        {
            results.Add(Render(board));
            return;
        }

        for (var c = 0; c < n; c += 1)
        {
            if (!IsSafe(board, r, c))
                continue;

            board[r, c] = true;
            PlaceRow(r + 1, board, n, results);
            board[r, c] = false;
        }
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