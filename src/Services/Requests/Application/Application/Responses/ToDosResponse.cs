using Application.Models;

namespace Application.Responses;

public class ToDosResponse
{
    public List<Todo> ToDos { get; init; }
}