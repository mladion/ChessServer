using MediatR;
using Shared.Models;

namespace Application.Features.Games.Queries;

public record GetAllGamesQuery : IRequest<IEnumerable<Game>>
{
}
