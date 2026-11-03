using Microsoft.EntityFrameworkCore;
using Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

// builder.Services.AddHttpClient("DummyApi", client =>
// {
//     client.BaseAddress = new Uri("https://dummyjson.com/todos");
// });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();