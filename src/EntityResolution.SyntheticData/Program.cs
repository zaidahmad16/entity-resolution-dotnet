using Bogus;
using EntityResolution.Core.Records;

// Generates synthetic people. No real personal data is ever used in this project.
//
// Milestone 1 TODO:
// 1. Take a count and an output path as arguments.
// 2. For a share of people, emit one or more "messy duplicates" using corruption rules:
//    typos, swapped given/surname, day and month swapped in the date of birth,
//    transliteration variants (Mohammed / Muhammad / Mohamed), missing fields.
// 3. Write a CSV with a hidden TrueEntityId column. That column is the ground truth
//    you evaluate precision and recall against later.

Randomizer.Seed = new Random(42); // Fixed seed so every run produces the same data.

var faker = new Faker();

for (var i = 0; i < 5; i++)
{
    var person = new PersonRecord(
        RecordId: $"R{i:D6}",
        GivenName: faker.Name.FirstName(),
        Surname: faker.Name.LastName(),
        DateOfBirth: DateOnly.FromDateTime(faker.Date.Past(60, DateTime.Today.AddYears(-18))),
        CountryOfBirth: faker.Address.CountryCode(),
        Sex: faker.PickRandom("F", "M", "X"));

    Console.WriteLine(person);
}
