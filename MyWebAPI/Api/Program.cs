using Api.Services;
using Api.Mcp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<ITodoService, TodosService>(client =>
{
    client.BaseAddress =
        new Uri("https://dummyjson.com/todos");
});

builder.Services.AddMcpServer().WithHttpTransport().WithToolsFromAssembly();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapMcp("/mcp");

app.Run();