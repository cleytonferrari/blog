using Blog.Infraestrutura.ConfigBd.EFCore;
using Blog.Infraestrutura.Dominio;
using Blog.Infraestrutura.Interfaces;
using Blog.Infraestrutura.Interfaces.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infraestrutura.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : ORMTipos
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguracao.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicacaoContexto>(options => options.UseNpgsql(conn));

            services.AddScoped(typeof(IRepositorioAsync<>), typeof(RepositorioAsync<>));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            

            return services;
        }
    }
}
