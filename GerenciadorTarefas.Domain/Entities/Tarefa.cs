using GerenciadorTarefas.Domain.Enums;
using System.Text.Json.Serialization;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Tarefa
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("data_vencimento")]
        public DateTime DataVencimento { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("prioridade")]
        public Prioridade Prioridade { get; set; }


        //Relacionamento
        [JsonPropertyName("projeto")]
        public Projeto Projeto { get; set; }
        [JsonPropertyName("projetoid")]
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
