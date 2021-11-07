using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Tailor.Entity.Auth;
using Microsoft.EntityFrameworkCore;

namespace E_Tailor.Persistence
{
    public class E_TailorContext: DbContext
    {
        public E_TailorContext(DbContextOptions<E_TailorContext> options) : base(options)
        { }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Rol>().ToTable("Rol");
        }
        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}
