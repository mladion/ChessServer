using Domain.IRepository;
using MediatR;
using Shared.Models;

namespace Application.Features.Games.Commands;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game
        {
            WhiteUserId = request.WhiteUserId,
            BlackUserId = request.BlackUserId,
            Status = "Active",
            CreatedAt = DateTime.UtcNow
        };

        return await _gameRepository.AddAsync(game);
    }
}
