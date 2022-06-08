using Application.Models;
using Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Endpoints;

public class GetToDoItems : EndpointWithoutRequest<ToDosResponse>
{
    private readonly TodoDb _todoDb;
    
    public GetToDoItems(TodoDb todoDb)
    {
        _todoDb = todoDb;
    }
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/todoitems");
        Description(x => x.Produces<List<Todo>>(200, "application/json"));
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var records = await _todoDb.Todos.ToListAsync(cancellationToken: ct);
        await SendAsync(new ToDosResponse
        {
            ToDos = records
        }, cancellation: ct);
    }
}