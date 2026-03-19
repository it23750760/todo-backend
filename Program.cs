var builder = WebApplication.CreateBuilder(args);

const string corsPolicy = "FrontendPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        policy
            .WithOrigins("http://localhost:3000", "https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(corsPolicy);

var todos = new[]
{
    new TodoItem(1, "Read the lab sheet", true),
    new TodoItem(2, "Run the backend API", false),
    new TodoItem(3, "Connect the React frontend", false)
};

app.MapGet("/api/todos", () => Results.Ok(todos));

app.Run();

record TodoItem(int Id, string Title, bool IsCompleted);
