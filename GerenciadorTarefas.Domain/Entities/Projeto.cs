namespace GerenciadorTarefas.Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
    }
}
