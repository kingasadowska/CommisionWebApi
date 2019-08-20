using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Elections.App.Database
{
    public class CandidateContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<SettingApp> SettingApp { get; set; }

        public CandidateContext(DbContextOptions<CandidateContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingApp>().HasData(
                new SettingApp {Id = 1, IsVoteExposed = false});

            modelBuilder.Entity<Candidates>()
                .HasMany(g => g.Users)
                .WithOne(g => g.Candidates)
                .HasForeignKey(s => s.CandidatesId);
        }
    }
}
