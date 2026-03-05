namespace MvnTruong.Algorithms.UnitTests;

public class NumIslandsTests
{
    [Theory]
    [InlineData((string[][])
    [
        ["1", "1", "1", "1", "0"],
        ["1", "1", "0", "1", "0"],
        ["1", "1", "0", "0", "0"],
        ["0", "0", "0", "0", "0"]
    ], 1)]
    [InlineData((string[][])
    [
        ["1", "1", "0", "0", "0"],
        ["1", "1", "0", "0", "0"],
        ["0", "0", "1", "0", "0"],
        ["0", "0", "0", "1", "1"]
    ], 3)]
    public void TopKFrequent_LeetCode_Tests(string[][] grid, int expected)
    {
        
    }
}
