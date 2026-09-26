namespace EntityResolution.Core.Similarity;

/// <summary>
/// Scores how alike two strings are, from 0.0 (nothing in common) to 1.0 (identical).
/// </summary>
public interface IStringSimilarity
{
    double Similarity(string a, string b);
}
