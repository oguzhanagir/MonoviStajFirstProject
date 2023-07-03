using Microsoft.EntityFrameworkCore;
using MonoviStajFirstProject.DataAccess.Configurations;
using MonoviStajFirstProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.DataAccess.Concrete
{
    public class MonoviStajFirstProjectDbContext : DbContext
    {

        public MonoviStajFirstProjectDbContext(DbContextOptions<MonoviStajFirstProjectDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
        public DbSet<User>? Users { get; set; }

    }
}
