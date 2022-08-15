using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Interface;

public interface IPOIContext
{
    DbSet<Domain.Entities.Point> Points { get; set; }

    Task<int> SaveChangeAsync();
}