namespace EntityResolution.Core.Similarity;

/// <summary>
/// Jaro-Winkler similarity, the standard choice for comparing personal names.
/// Jaro counts characters that match within a sliding window and penalizes
/// transpositions. Winkler then boosts pairs that share a common prefix,
/// because typos are rarer at the start of a name.
/// </summary>
public sealed class JaroWinkler : IStringSimilarity
{
    private readonly double _prefixScale;
    private readonly int _maxPrefixLength;

    /// <param name="prefixScale">How much a shared prefix boosts the score. 0.1 is the standard value.</param>
    /// <param name="maxPrefixLength">Longest prefix that counts toward the boost. 4 is the standard value.</param>
    public JaroWinkler(double prefixScale = 0.1, int maxPrefixLength = 4)
    {
        _prefixScale = prefixScale;
        _maxPrefixLength = maxPrefixLength;
    }

    /// <summary>
    /// TODO (milestone 1): plain Jaro similarity.
    /// Match window = max(len(a), len(b)) / 2 - 1.
    /// Jaro = (m/|a| + m/|b| + (m - t)/m) / 3, where m = matching chars and t = transpositions / 2.
    /// </summary>
    public static double Jaro(string a, string b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO (milestone 1): Jaro plus the Winkler prefix boost.
    /// JW = jaro + prefixLength * prefixScale * (1 - jaro).
    /// </summary>
    public double Similarity(string a, string b)
    {
        throw new NotImplementedException();
    }
}
