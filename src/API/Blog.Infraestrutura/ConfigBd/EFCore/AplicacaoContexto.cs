using Blog.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infraestrutura.ConfigBd.EFCore
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto()
        {

        }
        
        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> opcoes) : base(opcoes) { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseNpgsql(ConexaoBd.ConfiguracaoDaConexao
                                                .GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
