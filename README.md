# EntityResolution.NET

An open-source entity resolution library for .NET. It finds records that refer to the same person or company
across messy data: typos, swapped name order, accents, transliterated names
(Mohammed / Muhammad / Mohamed) and missing fields. All data is synthetic.

## Setup on Linux Mint

1. Install the .NET 10 SDK with Microsoft's install script (works on any distro):

   ```bash
   curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
   bash dotnet-install.sh --channel 10.0
   echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
   echo 'export PATH=$PATH:$HOME/.dotnet:$HOME/.dotnet/tools' >> ~/.bashrc
   source ~/.bashrc
   dotnet --version
   ```

2. Pick an editor: VS Code with the **C# Dev Kit** extension, or JetBrains **Rider**
   (free for non-commercial use). Both work well on Linux.

3. Build everything and run the tests:

   ```bash
   chmod +x bootstrap.sh
   ./bootstrap.sh
   dotnet test
   ```

   The tests fail at first. That's intended: they are the spec for milestone 1.

4. Later (milestone 2), for a local SQL Server, install Docker and run
   `docker compose up -d` after creating a `.env` file with `MSSQL_SA_PASSWORD=...`.

## Layout

| Project | What it is |
|---|---|
| `src/EntityResolution.Core` | The matching library: normalization, similarity, blocking, scoring |
| `src/EntityResolution.SyntheticData` | Generates fake people and messy duplicates with ground truth |
| `src/EntityResolution.Api` | ASP.NET Core API for "find matches for this record" |
| `tests/EntityResolution.Core.Tests` | xUnit tests |
| `bench/EntityResolution.Benchmarks` | BenchmarkDotNet speed measurements |

## Milestone 1: the matching building blocks

- [ ] Implement `Levenshtein.Distance` (full table first, then the two-row version)
- [ ] Implement `Levenshtein.Similarity`
- [ ] Implement `JaroWinkler.Jaro`, then `JaroWinkler.Similarity`
- [ ] Implement `NameNormalizer.Normalize` (rules are in its comments)
- [ ] All tests green: `dotnet test`
- [ ] Run the benchmarks: `dotnet run -c Release --project bench/EntityResolution.Benchmarks`
- [ ] Extend the synthetic data generator: N people, messy duplicates, CSV with a `TrueEntityId` column

## Later milestones

2. **Blocking and scoring.** Group candidate pairs (sorted neighbourhood, then MinHash/LSH),
   score each field, store records in SQL Server, measure precision and recall.
3. **Match model and API.** Train an ML.NET classifier on the field scores, serve
   `POST /match`, explain why each candidate matched.
4. **Azure.** Azure SQL Database, Azure Container Apps (API) and Container Apps Jobs (batch runs),
   Application Insights, Bicep, Azure Pipelines.
5. **Scale and write-up.** Millions of records, benchmark report, evaluation results.
