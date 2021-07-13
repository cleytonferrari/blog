﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infraestrutura.IoC
{
    public static class ResolveOrmIoC
    {
        public static void InfrastructureORM<T>(this IServiceCollection services, IConfiguration configuration = null) where T : IOrmTipos, new()
        {
            var ormType = new T();
            ormType.ResolveOrm(services, configuration);
        }
    }
}