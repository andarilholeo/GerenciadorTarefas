using System.Text.Json.Serialization;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Projeto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("tarefas")]
        public IEnumerable<Tarefa>? Tarefas { get; set; }

        public Projeto() { }

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
