using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infra.Context;

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
            throw new NotImplementedException();
        }

        public async Task<Projeto> ObterProjeto(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Projeto> ObterProjetoPorNome(string projectName)
        {
            throw new NotImplementedException();
        }

        public async Task<Projeto> CriarProjetoAsync(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public async Task<Projeto> AtualizarProjetoAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task DeletarProjetoAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
