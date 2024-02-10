using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Senha { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
    }
}
