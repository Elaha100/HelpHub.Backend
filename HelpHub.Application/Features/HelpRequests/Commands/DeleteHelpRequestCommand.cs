using HelpHub.Application.Interfaces;
using MediatR;

namespace HelpHub.Application.Features.HelpRequests.Commands;

public record DeleteHelpRequestCommand(int Id) : IRequest<bool>;

public class DeleteHelpRequestCommandHandler
    : IRequestHandler<DeleteHelpRequestCommand, bool>
{
    private readonly IHelpRequestRepository _repository;

    public DeleteHelpRequestCommandHandler(IHelpRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteHelpRequestCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
