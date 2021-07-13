using Blog.Infraestrutura.ConfigBd;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infraestrutura.IoC
{
    internal class ResolveConfiguracao
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? ConexaoBd.ConfiguracaoDaConexao;
        }
    }
}
