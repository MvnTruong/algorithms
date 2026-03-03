namespace MvnTruong.Algorithms.UnitTests;

public class LRUUnitTest
{
    [Fact]
    public void LRUCache_LeetCode_Case1()
    {
        string[] commands = ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"];
        int[][] values = [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]];

        int?[] expected = [null, null, null, 1, null, -1, null, -1, 3, 4];
        
        var logs = new List<int?>(commands.Length);

        LRUCache? cache = null;

        for (var i = 0; i < commands.Length; i += 1)
        {
            switch (commands[i])
            {
                case "LRUCache":
                {
                    var capacity = values[i][0];
                    cache = new LRUCache(capacity);
                    logs.Add(null);
                    break;
                }

                case "put":
                {
                    EnsureInitialized(cache);

                    var args = values[i];
                    var key = args[0];
                    var value = args[1];

                    cache!.Put(key, value);
                    logs.Add(null);
                    break;
                }

                case "get":
                {
                    EnsureInitialized(cache);

                    var key = values[i][0];
                    var result = cache!.Get(key);

                    logs.Add(result);
                    break;
                }

                default:
                    throw new InvalidOperationException($"Unknown command '{commands[i]}' at index {i}.");
            }
        }

        Assert.Equal(expected, logs.ToArray());
    }

    private static void EnsureInitialized(LRUCache? cache)
    {
        if (cache is null)
            throw new InvalidOperationException("LRUCache was not initialized. 'LRUCache' command must come first.");
    }
}
