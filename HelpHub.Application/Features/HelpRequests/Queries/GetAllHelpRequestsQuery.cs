using HelpHub.Application.DTOs;
using HelpHub.Application.Interfaces;
using MediatR;

namespace HelpHub.Application.Features.HelpRequests.Queries;

public record GetAllHelpRequestsQuery() : IRequest<List<HelpRequestDto>>;

public class GetAllHelpRequestsQueryHandler
    : IRequestHandler<GetAllHelpRequestsQuery, List<HelpRequestDto>>
{
    private readonly IHelpRequestRepository _repository;

    public GetAllHelpRequestsQueryHandler(IHelpRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<HelpRequestDto>> Handle(
        GetAllHelpRequestsQuery request,
        CancellationToken cancellationToken)
    {
        var helpRequests = await _repository.GetAllAsync();

        return helpRequests.Select(h => new HelpRequestDto
        {
            Id = h.Id,
            Title = h.Title,
            Description = h.Description,
            Location = h.Location,
            IsCompleted = h.IsCompleted,
            UserId = h.UserId,
            UserName = h.User != null ? h.User.Name : "",
            CategoryId = h.CategoryId,
            CategoryName = h.Category != null ? h.Category.Name : ""
        }).ToList();
    }
}