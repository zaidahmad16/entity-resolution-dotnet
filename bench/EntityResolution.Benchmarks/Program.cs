using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EntityResolution.Core.Similarity;

BenchmarkRunner.Run<SimilarityBenchmarks>();

[MemoryDiagnoser]
public class SimilarityBenchmarks
{
    private readonly JaroWinkler _jaroWinkler = new();

    [Params("mohammed|muhammad", "alexandrina|alexandra")]
    public string Pair { get; set; } = "";

    private string A = "";
    private string B = "";

    [GlobalSetup]
    public void Setup()
    {
        var parts = Pair.Split('|');
        A = parts[0];
        B = parts[1];
    }

    [Benchmark(Baseline = true)]
    public int LevenshteinDistance() => Levenshtein.Distance(A, B);

    [Benchmark]
    public double JaroWinklerSimilarity() => _jaroWinkler.Similarity(A, B);
}
