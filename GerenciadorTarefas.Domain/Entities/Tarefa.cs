using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Status Status { get; set; }
        public Prioridade Prioridade { get; set; }


        //Relacionamento
        public Projeto Projeto { get; set; }
        public int ProjetoId { get; set; }

        public Tarefa() { }

        public Tarefa(int id,
                        string titulo,
                        string descricao,
                        DateTime dataVencimento,
                        Status status,
                        Prioridade prioridade)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
            DataVencimento = dataVencimento;
            Status = status;
            Prioridade = prioridade;
        }
    }
}
