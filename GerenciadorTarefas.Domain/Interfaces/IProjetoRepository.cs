using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> ObterTodosProjetosDoUsuario();
        Task<Projeto> ObterProjeto(int? id);
        Task<Projeto> ObterProjetoPorNome(string projectName);
        Task<Projeto> CriarProjetoAsync(Projeto projeto);
        Task<Projeto> AtualizarProjetoAsync(int? id);
        Task DeletarProjetoAsync(int? id);
    }
}