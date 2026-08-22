using Domain.IRepository;
using MediatR;
using Shared.Models;

namespace Application.Features.Games.Queries;

public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<Game>>
{
    private readonly IGameRepository _gameRepository;

    public GetAllGamesQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IEnumerable<Game>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetAllAsync();
    }
}
