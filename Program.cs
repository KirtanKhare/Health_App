using HealthApp.Models;
using HealthApp.Dtos;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        Status = "Healthy",
        Name = "Kirtan Khare"
    });
});


var items = new List<Item>
{
    new Item { Id = 1, Name = "Book" },
    new Item { Id = 2, Name = "Laptop" },
    new Item { Id = 3, Name = "Mouse" }
};

app.MapGet("/api/items", () =>
{
    return Results.Ok(items);
});

app.MapPost("/api/items", (CreateItemDto dto) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name))
    {
        return Results.BadRequest(new
        {
            message = "Item name is required."           
        });
    }

    var nextId = items.Any()
        ? items.Max(i => i.Id) + 1
        : 1;
    
    var item = new Item
    {
        Id = nextId,
        Name = dto.Name
    };

    items.Add(item);

    return Results.Created($"/api/items/{item.Id}", item);
});

app.Run();