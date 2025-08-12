using System.ComponentModel.DataAnnotations.Schema;

namespace todo_list.Models;

public enum TodoPriotity
{
    Urgent = 1,
    Important = 2,
    Casual = 3
}

public class Todo
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public TodoPriotity Priority { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDate { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [NotMapped]
    public bool Edit { get; set; }
}
