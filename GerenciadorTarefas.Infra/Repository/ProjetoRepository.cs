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
            return await _context.Projetos.ToListAsync();
        }

        public async Task<Projeto> ObterProjeto(int? id)
        {
            return await _context.Projetos.FindAsync(id);
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

        public async Task<Projeto> AtualizarProjetoAsync(int? id)
        {
            var projeto = _context.Projetos.FirstOrDefault(x => x.Id == id);

            _context.Update(projeto);
            await _context.SaveChangesAsync();

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
