using HelpHub.Application.Interfaces;
using HelpHub.Domain.Entities;
using HelpHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpHub.Infrastructure.Repositories;

public class HelpRequestRepository : IHelpRequestRepository
{
    private readonly AppDbContext _context;

    public HelpRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<HelpRequest>> GetAllAsync()
    {
        return await _context.HelpRequests
            .Include(h => h.User)
            .Include(h => h.Category)
            .ToListAsync();
    }

    public async Task<HelpRequest?> GetByIdAsync(int id)
    {
        return await _context.HelpRequests
            .Include(h => h.User)
            .Include(h => h.Category)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<HelpRequest> CreateAsync(HelpRequest helpRequest)
    {
        _context.HelpRequests.Add(helpRequest);

        await _context.SaveChangesAsync();

        return helpRequest;
    }

    public async Task<bool> UpdateAsync(HelpRequest helpRequest)
    {
        _context.HelpRequests.Update(helpRequest);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var helpRequest =
            await _context.HelpRequests.FindAsync(id);

        if (helpRequest == null)
            return false;

        _context.HelpRequests.Remove(helpRequest);

        await _context.SaveChangesAsync();

        return true;
    }
}