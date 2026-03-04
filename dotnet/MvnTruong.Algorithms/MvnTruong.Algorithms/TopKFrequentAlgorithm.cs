namespace MvnTruong.Algorithms;

public class TopKFrequentAlgorithm
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> counts = new();

        for (var i = 0; i < nums.Length; i += 1) 
        {
            if(counts.ContainsKey(nums[i]))
            {
                counts[nums[i]] += 1;
            }
            else
            {
                counts[nums[i]] = 1;
            }
        }

        return counts
            .OrderByDescending(kv => kv.Value)
            .Select(a => a.Key)       
            .Take(k)
            .ToArray();
    }
}
