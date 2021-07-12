using Blog.API.Models.Base;
using System;
using System.Collections.Generic;

namespace Blog.API.Models
{
    public class Post:Entidade
    {
        public string Titulo { get; set; }
        public string Slug { get; set; }
        public string Conteudo { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Publicado { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }

    }
}
