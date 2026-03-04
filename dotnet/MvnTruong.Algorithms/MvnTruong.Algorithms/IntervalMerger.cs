namespace MvnTruong.Algorithms;

public static class IntervalMerger
{
    public static int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        
        int[] current = intervals[0];
        List<int[]> finals = [];
        
        for (var i = 1; i < intervals.Length; i += 1)
        {
            int[] interval = intervals[i];
            if (current[1] >= interval[0])
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
}
