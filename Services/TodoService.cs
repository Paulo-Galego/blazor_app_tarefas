using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo_list.Models;

namespace todo_list.Services;




public class TodoService
{
    private readonly TodoContext context;

    public TodoService(TodoContext context)
    {
        this.context = context;
    }


    public async Task<List<Todo>> GetActiveTodosAsync()
    {
        var list = await context.Todos
            .Where(e => !e.Done)
            .OrderByDescending(e => e.Priority > 0)
            .ThenBy (e=> e.Priority)
            .ToListAsync();
        return list;
    }

    public async Task NewTodoAsync()
    {
        await context.Todos.AddAsync(new Todo
        {
            Title = $"Tarefa {DateTime.Now}",
            Description = $"Description {DateTime.Now}",
            CategoryId = 1,
        });
        await context.SaveChangesAsync();
    }

    public async Task<Todo> UpdateTodoAsync(Todo todo)
    {
        context.Update(todo);
        await context.SaveChangesAsync();
        return todo;
    }
    //Remove
    public async Task RemoveTodoAsync(Todo todo)
    {
        context.Remove(todo);
        await context.SaveChangesAsync();
    }
}

