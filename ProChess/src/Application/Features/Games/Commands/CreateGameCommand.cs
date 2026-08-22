using MediatR;
using Shared.Models;

namespace Application.Features.Games.Commands;

public record CreateGameCommand(string WhiteUserId, string BlackUserId) : IRequest<Game>
{
}
