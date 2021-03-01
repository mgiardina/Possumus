using Microsoft.EntityFrameworkCore;
using Possumus.Infrastructure.Data.Entities;
using System;

namespace Possumus.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Empleo> Empleos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data           
            modelBuilder.Entity<Candidato>()
                .HasData(
                    new Candidato { Id = 1, Nombre = "Mariano", Apellido = "Giardina", FechaNacimiento = new DateTime(1982,4,24), Email = "mgiardina@gmail.com", Telefono = "+5492317517703" },
                    new Candidato { Id = 2, Nombre = "Juan", Apellido = "Perez", FechaNacimiento = new DateTime(1980, 4, 24), Email = "juan@gmail.com", Telefono = "+5492317515544" }
                );
        }
    }
}
