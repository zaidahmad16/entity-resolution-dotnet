namespace EntityResolution.Core.Records;

/// <summary>
/// One person as stored in a source system. Fields are nullable on purpose:
/// real records are often incomplete, and the matcher has to cope with that.
/// </summary>
public sealed record PersonRecord(
    string RecordId,
    string? GivenName,
    string? Surname,
    DateOnly? DateOfBirth,
    string? CountryOfBirth,
    string? Sex);
