using System.ComponentModel;
using Api.Models;
using Api.Services;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace Api.Mcp;

[McpServerToolType]
public class TodoTools(ITodoService service)
{
    [McpServerTool(Name = "get_todos"), Description("Retrieves the full list of todos.")]
    public async Task<string> GetTodos()
    {
        try
        {
            return await service.GetTodosAsync();
        }
        catch (ApiException ex)
        {
            // surfaced to the calling agent as tool content rather than an
            // unhandled exception
            throw new McpException($"{ex.Status} {ex.Error}: {ex.Message}");
        }
    }

    [McpServerTool(Name = "post_todo"), Description("Creates a new todo item.")]
    public async Task<string> PostTodo(
        [Description("The todo item to create.")] TodoDto todo)
    {
        try
        {
            return await service.PostTodoAsync(todo);
        }
        catch (ApiException ex)
        {
            throw new McpException($"{ex.Status} {ex.Error}: {ex.Message}");
        }
    }
}