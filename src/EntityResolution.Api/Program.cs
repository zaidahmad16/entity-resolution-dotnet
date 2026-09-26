var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// Milestone 3: POST /match takes a PersonRecord and returns ranked candidate matches.

app.Run();
