namespace Blog.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}
