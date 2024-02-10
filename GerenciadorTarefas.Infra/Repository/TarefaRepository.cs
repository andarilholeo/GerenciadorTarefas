using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infra.Context;

namespace GerenciadorTarefas.Infra.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Tarefa>> ObterTodasTarefasDoProjetoAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> ObterTarefaAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> AtualizarTarefaAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverTarefa(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
