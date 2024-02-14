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

        public async Task<IEnumerable<Tarefa>> ObterTodasTarefasDoProjetoAsync(int? id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            return projeto.Tarefas;
        }

        public async Task<Tarefa> ObterTarefaAsync(int? id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            return tarefa;
        }

        public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
        {
            _context.Add(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> AtualizarTarefaAsync(int? id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(x => x.Id == id);

            _context.Update(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task RemoverTarefa(int? id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefa);

            await _context.SaveChangesAsync();
        }
    }
}
