using EntityResolution.Core.Normalization;

namespace EntityResolution.Core.Tests;

public class NameNormalizerTests
{
    [Theory]
    [InlineData("José Núñez", "jose nunez")]
    [InlineData("Al-Hassan", "al hassan")]
    [InlineData("Hassan, Mohamed", "hassan mohamed")]
    [InlineData("O'Brien", "obrien")]
    [InlineData("  MARY   ann  ", "mary ann")]
    [InlineData("Zoë Müller-Lüdenscheidt", "zoe muller ludenscheidt")]
    [InlineData("J.R.R. Tolkien", "j r r tolkien")]
    public void Normalize_ProducesCanonicalForm(string input, string expected)
    {
        Assert.Equal(expected, NameNormalizer.Normalize(input));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Normalize_BlankInput_ReturnsEmpty(string? input)
    {
        Assert.Equal(string.Empty, NameNormalizer.Normalize(input));
    }
}
