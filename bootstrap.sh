#!/usr/bin/env bash
# Creates the solution file and adds every project to it. Run once after cloning.
set -euo pipefail
cd "$(dirname "$0")"

if ls EntityResolution.sln* >/dev/null 2>&1; then
  echo "Solution already exists."
else
  dotnet new sln -n EntityResolution
fi

dotnet sln add \
  src/EntityResolution.Core/EntityResolution.Core.csproj \
  src/EntityResolution.Api/EntityResolution.Api.csproj \
  src/EntityResolution.SyntheticData/EntityResolution.SyntheticData.csproj \
  tests/EntityResolution.Core.Tests/EntityResolution.Core.Tests.csproj \
  bench/EntityResolution.Benchmarks/EntityResolution.Benchmarks.csproj

dotnet restore
dotnet build
echo
echo "Done. Run the tests with: dotnet test"
