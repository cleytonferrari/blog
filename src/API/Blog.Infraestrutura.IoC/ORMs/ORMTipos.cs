using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infraestrutura.IoC.ORMs
{
    public abstract class ORMTipos : IOrmTipos
    {
        internal abstract IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null);
        public IServiceCollection ResolveOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            return AddOrm(services, configuration);
        }
    }
}
