using CadastroDeUsuario.Repositorio;
using CadastroDeUsuario.Repositorio.ConexaoBancoDeDados;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CadastroDeUsuario
{
    public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            public IConfiguration Configuration { get; set; }

            public void ConfigureServices(IServiceCollection servicos)
            {
                var stringDeConexao = Configuration.GetConnectionString("Default");

                servicos.AddDbContext<ContextoDaAplicacao>(c => c.UseSqlServer(stringDeConexao));
                
                servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

                servicos.AddControllers();
                servicos.AddCors();
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseCors(opcao => opcao.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                serviceProvider.GetService<ContextoDaAplicacao>().Database.Migrate();
            }
        }
}
