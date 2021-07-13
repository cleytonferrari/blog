using Blog.Aplicacao.Dominio;
using Blog.Aplicacao.Interfaces;
using Blog.Aplicacao.Interfaces.Dominio;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blog.Aplicacao.IoC
{
    public static class AplicacaoIoC
    {
        public static void AplicacaoIoCServico(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAplicacaoBase<>),typeof(AplicacaoBase<>));

            services.AddScoped(typeof(IUsuarioAplicacao),typeof(UsuarioAplicacao));
        }
    }
}
