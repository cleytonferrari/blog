using Blog.API.Models.Base;
using System;

namespace Blog.API.Models
{
    public class Comentario : Entidade
    {
        public string Autor { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
    }
}