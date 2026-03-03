namespace MvnTruong.Algorithms;

public class IntervalMerger
{
    public int[][] Merge(int[][] intervals)
    {
        return [];
    }
    
    private bool Overlaps(int[] a, int[] b) => a[1] >= b[0] && a[0] <= b[1];
}
