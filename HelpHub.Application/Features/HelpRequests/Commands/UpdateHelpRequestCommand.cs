using HelpHub.Application.Interfaces;
using HelpHub.Domain.Entities;
using MediatR;

namespace HelpHub.Application.Features.HelpRequests.Commands;

public record UpdateHelpRequestCommand(
    int Id,
    string Title,
    string Description,
    string Location,
    bool IsCompleted,
    int UserId,
    int CategoryId
) : IRequest<bool>;

public class UpdateHelpRequestCommandHandler
    : IRequestHandler<UpdateHelpRequestCommand, bool>
{
    private readonly IHelpRequestRepository _repository;

    public UpdateHelpRequestCommandHandler(IHelpRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateHelpRequestCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);

        if (existing == null)
            return false;

        existing.Title = request.Title;
        existing.Description = request.Description;
        existing.Location = request.Location;
        existing.IsCompleted = request.IsCompleted;
        existing.UserId = request.UserId;
        existing.CategoryId = request.CategoryId;

        return await _repository.UpdateAsync(existing);
    }
}