using Domain.IRepository;
using MediatR;
using Shared.Models;

namespace Application.Features.Games.Queries;

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Game?>
{
    private readonly IGameRepository _gameRepository;

    public GetGameByIdQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetGameWithPlayersAsync(request.GameId);
    }
}
