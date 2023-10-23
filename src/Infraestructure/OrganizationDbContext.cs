using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class OrganizationDbContext: DbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne<Organization>(s => s.Organization)
            .WithMany(r => r.Users)
            .HasForeignKey(s => s.OrganizationId);
        }


        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
