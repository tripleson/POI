using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        public async Task<int> SaveChangeAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
