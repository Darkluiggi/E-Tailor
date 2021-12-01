using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Tailor.Entity.Appointments;
using E_Tailor.Entity.Auth;
using E_Tailor.Entity.Users;
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

            modelBuilder.Entity<Manager>().ToTable("Managers");

            modelBuilder.Entity<Costumer>().ToTable("Costumers");
            modelBuilder.Entity<Tailor>().ToTable("Tailors");

            modelBuilder.Entity<Appointment>().ToTable("Apointments");
            modelBuilder.Entity<Cloth>().ToTable("Clothes");
            modelBuilder.Entity<Registry>().ToTable("Registries");
        }
        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Tailor> Tailors { get; set; }
        public DbSet<Appointment > Appointments { get; set; }
        public DbSet<Cloth> Clothes { get; set; }
        public DbSet<Registry> Registries { get; set; }
    }
}
