using HelpHub.Application.DTOs;
using HelpHub.Application.Interfaces;
using MediatR;

namespace HelpHub.Application.Features.HelpRequests.Queries;

public record GetHelpRequestByIdQuery(int Id) : IRequest<HelpRequestDto?>;

public class GetHelpRequestByIdQueryHandler
    : IRequestHandler<GetHelpRequestByIdQuery, HelpRequestDto?>
{
    private readonly IHelpRequestRepository _repository;

    public GetHelpRequestByIdQueryHandler(IHelpRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<HelpRequestDto?> Handle(
        GetHelpRequestByIdQuery request,
        CancellationToken cancellationToken)
    {
        var helpRequest = await _repository.GetByIdAsync(request.Id);

        if (helpRequest == null)
            return null;

        return new HelpRequestDto
        {
            Id = helpRequest.Id,
            Title = helpRequest.Title,
            Description = helpRequest.Description,
            Location = helpRequest.Location,
            IsCompleted = helpRequest.IsCompleted,
            UserId = helpRequest.UserId,
            UserName = helpRequest.User?.Name ?? "",
            CategoryId = helpRequest.CategoryId,
            CategoryName = helpRequest.Category?.Name ?? ""
        };
    }
}