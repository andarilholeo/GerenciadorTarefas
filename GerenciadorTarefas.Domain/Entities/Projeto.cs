namespace GerenciadorTarefas.Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }

        public Projeto() { }

        public Projeto(int id, 
                        string nome, 
                        IEnumerable<Tarefa> tarefas)
        {
            Id = id;
            Nome = nome;
            Tarefas = tarefas;
        }
    }
}
