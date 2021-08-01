using curso.Api.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.Api.Configurations
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=CursoApi;User Id=postgres;Password=12345678;");
            CursoDbContext contexto = new(optionsBuilder.Options);

            return contexto;
        }
    }
}
