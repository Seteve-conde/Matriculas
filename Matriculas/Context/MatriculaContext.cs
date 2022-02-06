using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matriculas.Models;

namespace Matriculas.Context
{
    public class MatriculaContext : DbContext
    {
        public MatriculaContext(DbContextOptions<MatriculaContext> options) : base(options) { }
        public DbSet<Matricula> Matricula { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>()
                .Property(p => p.Nome)
                .HasMaxLength(50);

            modelBuilder.Entity<Matricula>()
                .Property(p => p.NumMatricula)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Matricula>()
                .HasData(
                new Matricula { Id = 1, Nome = "João", NumMatricula = 1});
        }

    }
}
