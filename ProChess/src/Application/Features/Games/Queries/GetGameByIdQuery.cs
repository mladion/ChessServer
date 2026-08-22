using MediatR;
using Shared.Models;

namespace Application.Features.Games.Queries;

public record GetGameByIdQuery(int GameId) : IRequest<Game?>
{
}
