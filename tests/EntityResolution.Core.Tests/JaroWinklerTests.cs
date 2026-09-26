using EntityResolution.Core.Similarity;

namespace EntityResolution.Core.Tests;

public class JaroWinklerTests
{
    // Classic reference pairs from the record linkage literature, plus a name from our domain.
    [Theory]
    [InlineData("martha", "marhta", 0.9444)]
    [InlineData("dwayne", "duane", 0.8222)]
    [InlineData("dixon", "dicksonx", 0.7667)]
    [InlineData("mohammed", "muhammad", 0.8333)]
    [InlineData("abc", "xyz", 0.0)]
    [InlineData("", "", 1.0)]
    public void Jaro_MatchesKnownValues(string a, string b, double expected)
    {
        Assert.Equal(expected, JaroWinkler.Jaro(a, b), precision: 4);
    }

    [Theory]
    [InlineData("martha", "marhta", 0.9611)]
    [InlineData("dwayne", "duane", 0.84)]
    [InlineData("dixon", "dicksonx", 0.8133)]
    [InlineData("mohammed", "muhammad", 0.85)]
    [InlineData("abc", "xyz", 0.0)]
    public void JaroWinkler_MatchesKnownValues(string a, string b, double expected)
    {
        Assert.Equal(expected, new JaroWinkler().Similarity(a, b), precision: 4);
    }

    [Fact]
    public void SharedPrefix_ScoresHigherThanPlainJaro()
    {
        var jw = new JaroWinkler();
        Assert.True(jw.Similarity("martha", "marhta") > JaroWinkler.Jaro("martha", "marhta"));
    }

    [Fact]
    public void Similarity_IsSymmetric()
    {
        var jw = new JaroWinkler();
        Assert.Equal(jw.Similarity("dixon", "dicksonx"), jw.Similarity("dicksonx", "dixon"), precision: 10);
    }
}
