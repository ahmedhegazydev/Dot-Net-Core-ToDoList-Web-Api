namespace MyApp.Application;

// Query  ➜ returns all todos
public record GetTodosQuery() : IRequest<IEnumerable<TodoDto>>;

public class GetTodosHandler : IRequestHandler<GetTodosQuery,IEnumerable<TodoDto>>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _ctx;

    public GetTodosHandler(IAppDbContext ctx, IMapper mapper)
        => (_ctx,_mapper) = (ctx,mapper);

    public async Task<IEnumerable<TodoDto>> Handle(GetTodosQuery q, CancellationToken ct)
        => _mapper.ProjectTo<TodoDto>(_ctx.Todos).ToList();
}

// Command ➜ create a todo
public record CreateTodoCommand(string Title) : IRequest<Guid>;
public class CreateTodoHandler : IRequestHandler<CreateTodoCommand,Guid>
{
    private readonly IAppDbContext _ctx;
    public CreateTodoHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<Guid> Handle(CreateTodoCommand c, CancellationToken ct)
    {
        var todo = new Todo();
        todo.Rename(c.Title);

        _ctx.Todos.Add(todo);
        await _ctx.SaveChangesAsync(ct);
        return todo.Id;
    }
}
