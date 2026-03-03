namespace MvnTruong.Algorithms;

public static class IntervalMerger
{
    public static int[][] Merge(int[][] intervals)
    {
        int[][] sorted = intervals.OrderBy(x => x[0]).ToArray(); // n log n

        int[] current = sorted[0];
        List<int[]> finals = [];
        
        for (var i = 1; i < sorted.Length; i += 1)
        {
            int[] interval = sorted[i];
            if (Overlaps(current, interval))
            {
                current[1] = Math.Max(current[1], interval[1]);
            }
            else
            {
                finals.Add(current);
                current = interval;
            }
        }

        finals.Add(current);
        
        return finals.ToArray();
    }
    
    private static bool Overlaps(int[] a, int[] b) => a[1] >= b[0] && a[0] <= b[1];
}
