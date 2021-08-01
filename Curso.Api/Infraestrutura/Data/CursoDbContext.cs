using curso.Api.Business.Entities;
using curso.Api.Infraestrutura.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.Api.Infraestrutura.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Curso> Curso { get; set; }

    }
}
