var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

int major = 1;
int minor = 0;
int patch = 0;

app.MapGet("/version", () =>
{
    return $"{major}.{minor}.{patch}";
});

app.MapPost("/version/minor", () =>
{
    minor++;
});

app.MapPost("/version/patch", () =>
{
    patch++;
});


app.Run("http://0.0.0.0:5555");