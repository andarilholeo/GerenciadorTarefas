using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodasTarefasDoProjetoAsync(int? id);
        Task<Tarefa> ObterTarefaAsync(int? id);
        Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
        Task<Tarefa> AtualizarTarefaAsync(int? id);
        Task RemoverTarefa(int? id);
    }
}