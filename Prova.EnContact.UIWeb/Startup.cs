using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prova.EnContact.Modelos.Modelos;
using Prova.EnContact.Mapeadores.Data;
using Prova.EnContact.Servicos.Servicos;
using Prova.EnContact.Interfaces.Interfaces.Servicos;
using Prova.EnContact.Interfaces.Interfaces.Modelos;
using Prova.EnContact.Compartilhado.Constantes;

namespace Prova.EnContact.UIWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var bancoParaUso = Configuration.GetValue<string>("ConfiguracoesDaAplicacao:BancoDeDadosUtilizado");

            if (string.Equals(bancoParaUso, ConstantesUtilitarios.SQL_SERVER, StringComparison.InvariantCultureIgnoreCase))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
            else if(string.Equals(bancoParaUso, ConstantesUtilitarios.SQLITE, StringComparison.InvariantCultureIgnoreCase))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetValue<string>("BDProducao:SQliteBDConnectionString"),
                    x => x.SuppressForeignKeyEnforcement()));
            }

            services.AddTransient(typeof(IRecadoServico<Recado>), typeof(RecadoServico));
            services.AddTransient(typeof(IAgrupamentoServico<Agrupamento>), typeof(AgrupamentoServico));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Erros/Erro");
                app.UseStatusCodePagesWithReExecute("/Erros/{0}");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
