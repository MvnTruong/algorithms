using System.Diagnostics.CodeAnalysis;
using FluentAssertions;

namespace MvnTruong.Algorithms.UnitTests;

[SuppressMessage("Performance", "CA1861:Avoid constant arrays as arguments")]
public class TopKFrequentAlgorithmTests
{
    [Theory]
    [InlineData(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
    [InlineData(new[] { 1 }, 1, new[] { 1 })]
    [InlineData(new[] { 1, 2, 1, 2, 1, 2, 3, 1, 3, 2 }, 2, new[] { 1, 2 })]
    public void TopKFrequent_LeetCode_Tests(int[] intervals, int k, int[] expected)
    {
        TopKFrequentAlgorithm sut = new();
        int[] output = sut.TopKFrequent(intervals, k);
        output.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }
}
