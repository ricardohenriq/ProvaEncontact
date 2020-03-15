using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Prova.EnContact.Compartilhado.Utilitarios;
using Prova.EnContact.Mapeadores.Data.Maps;
using Prova.EnContact.Modelos.Modelos;

namespace Prova.EnContact.Mapeadores.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public DbSet<Recado> Recados { get; set; }

        public DbSet<Agrupamento> Agrupamentos { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecadoMap());
            builder.ApplyConfiguration(new AgrupamentoMap());

            base.OnModelCreating(builder);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var appSettings = UtilitarioDeArquivos.CarregueJsonArquivo("appsettings.json");
            var conexaoDoBanco = appSettings.ConnectionStrings.DefaultConnection;
            var conexaoDoBancoString = ((JValue)conexaoDoBanco).Value as string;

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(conexaoDoBancoString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
