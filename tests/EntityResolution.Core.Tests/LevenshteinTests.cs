using EntityResolution.Core.Similarity;

namespace EntityResolution.Core.Tests;

public class LevenshteinTests
{
    [Theory]
    [InlineData("kitten", "sitting", 3)]
    [InlineData("flaw", "lawn", 2)]
    [InlineData("", "abc", 3)]
    [InlineData("abc", "", 3)]
    [InlineData("abc", "abc", 0)]
    [InlineData("", "", 0)]
    [InlineData("mohammed", "muhammad", 2)]
    [InlineData("mohammed", "mohamed", 1)]
    public void Distance_MatchesKnownValues(string a, string b, int expected)
    {
        Assert.Equal(expected, Levenshtein.Distance(a, b));
    }

    [Fact]
    public void Distance_IsSymmetric()
    {
        Assert.Equal(Levenshtein.Distance("alhassan", "hassan"), Levenshtein.Distance("hassan", "alhassan"));
    }

    [Theory]
    [InlineData("kitten", "sitting", 0.5714)]
    [InlineData("mohammed", "mohamed", 0.875)]
    [InlineData("abc", "abc", 1.0)]
    [InlineData("", "", 1.0)]
    [InlineData("", "abc", 0.0)]
    public void Similarity_IsNormalizedByLongerString(string a, string b, double expected)
    {
        Assert.Equal(expected, new Levenshtein().Similarity(a, b), precision: 4);
    }
}
