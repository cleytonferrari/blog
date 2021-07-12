using Blog.API.Models.Base;

namespace Blog.API.Models
{
    public class Categoria: Entidade
    {
        public string Nome { get; set; }
        public string Slug { get; set; }
    }
}