using System.Reflection;
using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class POIContext : DbContext, IPOIContext
{
    public POIContext(DbContextOptions<POIContext> options) : base(options) { }
    
    public DbSet<Domain.Entities.Point> Points { get; set; }
    
    public async Task<int> SaveChangeAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}