using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodasTarefasDoProjetoAsync(int? id);
        Task<IEnumerable<Tarefa>> ObterTodasAsTarefas();
        Task<Tarefa> ObterTarefaAsync(int? id);
        Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
        Task<Tarefa> AtualizarTarefaAsync(Tarefa? tarefa);
        Task RemoverTarefa(int? id);
    }
}