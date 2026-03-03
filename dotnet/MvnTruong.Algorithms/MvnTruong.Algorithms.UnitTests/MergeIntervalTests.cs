using FluentAssertions;

namespace MvnTruong.Algorithms.UnitTests;

public class MergeIntervalTests
{
    [Theory]
    [MemberData(nameof(Cases))]
    public void MergeInterval_LeetCode_Tests(int[][] intervals, int[][] expected)
    {
        IntervalMerger sut = new();
        int[][] result = sut.Merge(intervals);
        
        result.Should().BeEquivalentTo(expected, options => 
            options.WithStrictOrdering());
    }

    public static IEnumerable<object[]> Cases =>
    [
        [
            new[]
            {
                new[] { 1, 3 },
                new[] { 2, 6 },
                new[] { 8, 10 },
                new[] { 15, 18 }
            },
            new[]
            {
                new[] { 1, 6 },
                new[] { 8, 10 },
                new[] { 15, 18 }
            },
        ],

        [
            new[]
            {
                new[] { 1, 4 },
                new[] { 4, 5 }
            },
            new[]
            {
                new[] { 1, 5 }
            },
        ],

        [
            new[]
            {
                new[] { 4, 7 },
                new[] { 1, 4 }
            },
            new[]
            {
                new[] { 1, 7 }
            },
        ],

        // no overlap
        [
            new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 }
            },
            new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 }
            },
        ],

        // fully nested
        [
            new[]
            {
                new[] { 1, 10 },
                new[] { 2, 3 },
                new[] { 4, 8 }
            },
            new[]
            {
                new[] { 1, 10 }
            },
        ]
    ];
}

