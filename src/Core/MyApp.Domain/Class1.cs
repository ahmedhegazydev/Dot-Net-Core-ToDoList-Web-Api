// src/Core/MyApp.Domain/Entities/Todo.cs
namespace MyApp.Domain.Entities;

public class Todo
{
    public Guid Id            { get; private set; } = Guid.NewGuid();
    public string Title       { get; private set; } = null!;
    public bool   IsCompleted { get; private set; }

    // enforce invariants through methods (encapsulation)
    public void Rename(string newTitle) => Title = newTitle.Trim();
    public void Complete()              => IsCompleted = true;
}
