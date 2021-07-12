using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infraestrutura.ConfigBd
{
    public class ConexaoBd
    {
        public static IConfiguration ConfiguracaoDaConexao
        {
            get
            {
                IConfiguration Configuracao = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuracao;
            }
        }
    }
}
