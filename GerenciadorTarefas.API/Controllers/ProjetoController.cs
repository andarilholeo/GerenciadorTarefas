using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> ObterProjetos()
        {
            var projetos = await _projetoRepository.ObterTodosProjetosDoUsuario();

            if (projetos is null)
                return NotFound("Projetos não encontrados");

            return Ok(projetos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Projeto>> ObterProjetoId(int? id)
        {
            var projeto = await _projetoRepository.ObterProjeto(id);

            if (projeto is null)
                return NotFound("projeto não encontrado");

            return Ok(projeto);
        }

        [HttpPost]
        public async Task<ActionResult> CriarProjeto([FromBody] Projeto projeto)
        {
            if (projeto is null)
                return BadRequest("Invalid Data");

            await _projetoRepository.CriarProjetoAsync(projeto);

            return Ok(projeto);
        }

        [HttpPut]
        public async Task<ActionResult> Updateprojeto([FromBody] Projeto projeto)
        {
            if (projeto == null)
                return BadRequest();

            await _projetoRepository.AtualizarProjetoAsync(projeto);
            return Ok(projeto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Deleteprojeto(int id)
        {
            var projeto = await _projetoRepository.ObterProjeto(id);
            if (projeto is null)
                return BadRequest();

            await _projetoRepository.DeletarProjetoAsync(id);
            return Ok();
        }
    }
}
