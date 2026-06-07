using HelpHub.Application.DTOs;
using HelpHub.Application.Interfaces;
using HelpHub.Domain.Entities;
using MediatR;

namespace HelpHub.Application.Features.HelpRequests.Commands;

public record CreateHelpRequestCommand(
    string Title,
    string Description,
    string Location,
    int UserId,
    int CategoryId
) : IRequest<HelpRequestDto>;

public class CreateHelpRequestCommandHandler
    : IRequestHandler<CreateHelpRequestCommand, HelpRequestDto>
{
    private readonly IHelpRequestRepository _repository;

    public CreateHelpRequestCommandHandler(IHelpRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<HelpRequestDto> Handle(
        CreateHelpRequestCommand request,
        CancellationToken cancellationToken)
    {
        var helpRequest = new HelpRequest
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            IsCompleted = false
        };

        var created = await _repository.CreateAsync(helpRequest);

        return new HelpRequestDto
        {
            Id = created.Id,
            Title = created.Title,
            Description = created.Description,
            Location = created.Location,
            IsCompleted = created.IsCompleted,
            UserId = created.UserId,
            CategoryId = created.CategoryId
        };
    }
}