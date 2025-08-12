using System;
using Microsoft.EntityFrameworkCore;

namespace todo_list.Models;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();
    public DbSet<Category> Categories => Set<Category>();


    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(e => e.Description).IsRequired();

        modelBuilder.Entity<Todo>().Property(e => e.Title).IsRequired();
        modelBuilder.Entity<Todo>().Property(e => e.Description).IsRequired();

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Description = "Trabalho" },
            new Category { Id = 2, Description = "Pessoal" },
            new Category { Id = 3, Description = "Outro" }
        );
    }


}
