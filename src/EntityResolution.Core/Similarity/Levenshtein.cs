namespace EntityResolution.Core.Similarity;

/// <summary>
/// Edit distance: the fewest single-character insertions, deletions or
/// substitutions needed to turn one string into the other.
/// </summary>
public sealed class Levenshtein : IStringSimilarity
{
    /// <summary>
    /// TODO (milestone 1): implement with dynamic programming.
    /// Start with the full table, then optimize to two rows so memory is O(min(a, b)).
    /// </summary>
    public static int Distance(string a, string b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Distance turned into a 0..1 similarity: 1 - distance / length of the longer string.
    /// Two empty strings count as identical.
    /// </summary>
    public double Similarity(string a, string b)
    {
        throw new NotImplementedException();
    }
}
