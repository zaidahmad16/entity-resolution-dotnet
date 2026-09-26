namespace EntityResolution.Core.Normalization;

/// <summary>
/// Puts names into a canonical form before comparison, so formatting
/// differences don't count as real differences.
/// </summary>
public static class NameNormalizer
{
    /// <summary>
    /// TODO (milestone 1). Rules, in order:
    /// 1. Lowercase (use the invariant culture).
    /// 2. Strip accents: decompose with NormalizationForm.FormD, drop characters whose
    ///    UnicodeCategory is NonSpacingMark, then recompose with FormC.
    /// 3. Remove apostrophes entirely (O'Brien -> obrien).
    /// 4. Turn hyphens, commas and periods into spaces (Al-Hassan -> al hassan).
    /// 5. Collapse runs of whitespace into one space and trim.
    /// Null or blank input returns an empty string.
    /// </summary>
    public static string Normalize(string? name)
    {
        throw new NotImplementedException();
    }
}
