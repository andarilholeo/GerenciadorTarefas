using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Infra.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjetoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Projeto>> ObterTodosProjetosDoUsuario()
        {
            return await _context.Projetos
                .Include(t => t.Tarefas)
                .ToListAsync();
        }

        public async Task<Projeto> ObterProjeto(int? id)
        {
            return await _context.Projetos
                .Include(p => p.Tarefas)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Projeto> ObterProjetoPorNome(string projectName)
        {
            var projeto = await _context.Projetos.Where(x => x.Nome.ToLower().Contains(projectName.ToLower())).ToListAsync();
            return projeto.First();
        }

        public async Task<Projeto> CriarProjetoAsync(Projeto projeto)
        {
            _context.Add(projeto);
            await _context.SaveChangesAsync();

            return projeto;
        }

        public async Task<Projeto> AtualizarProjetoAsync(Projeto projeto)
        {
            var projetoAtualizar = _context.Projetos.AsNoTracking().FirstOrDefault(x => x.Id == projeto.Id);

            if (projetoAtualizar is not null)
            {
                _context.Update(projeto);
                await _context.SaveChangesAsync();
            }

            return projeto;
        }

        public async Task DeletarProjetoAsync(int? id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            _context.Projetos.Remove(projeto);

            await _context.SaveChangesAsync();
        }
    }
}
