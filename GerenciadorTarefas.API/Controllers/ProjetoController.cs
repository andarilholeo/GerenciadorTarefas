using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers
{
    [Route("api/[controller]")]
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
                return NotFound("Categories not Found");

            return Ok(projetos);
        }

        [HttpGet("{id:int}", Name = "Getprojeto")]
        public async Task<ActionResult<Projeto>> ObterProjetoId(int? id)
        {
            var projeto = await _projetoRepository.ObterProjeto(id);

            if (projeto is null)
                return NotFound("projeto not Found");

            return Ok(projeto);
        }

        [HttpPost]
        public async Task<ActionResult> CriarProjeto([FromBody] Projeto projeto)
        {
            if (projeto is null)
                return BadRequest("Invalid Data");

            await _projetoRepository.CriarProjetoAsync(projeto);

            return new CreatedAtRouteResult("Getprojeto", new { id = projeto.Id }, projeto);
        }

        [HttpPut]
        public async Task<ActionResult> Updateprojeto(int? id, [FromBody] Projeto projeto)
        {
            if (id != projeto.Id)
                return BadRequest();

            if (projeto == null)
                return BadRequest();

            await _projetoRepository.AtualizarProjetoAsync(id);
            return Ok(projeto);
        }

        [HttpDelete]
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
