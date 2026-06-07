using HelpHub.Domain.Entities;

namespace HelpHub.Application.Interfaces;

public interface IHelpRequestRepository
{
    Task<List<HelpRequest>> GetAllAsync();

    Task<HelpRequest?> GetByIdAsync(int id);

    Task<HelpRequest> CreateAsync(HelpRequest helpRequest);

    Task<bool> UpdateAsync(HelpRequest helpRequest);

    Task<bool> DeleteAsync(int id);
}
