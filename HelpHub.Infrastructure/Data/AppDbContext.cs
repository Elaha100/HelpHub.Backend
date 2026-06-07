using HelpHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpHub.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<HelpRequest> HelpRequests => Set<HelpRequest>();
}
