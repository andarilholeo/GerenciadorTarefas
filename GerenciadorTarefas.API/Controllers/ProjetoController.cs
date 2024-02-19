using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;

        public ProjetoController(IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository)
        {
            _projetoRepository = projetoRepository;
            _tarefaRepository = tarefaRepository;
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


        [HttpPut]
        public async Task<ActionResult> AdicionarTarefasAoProjeto(int? idProjeto, int? idTarefa)
        {
            var projeto = await _projetoRepository.ObterProjeto(idProjeto);
            var tarefa = await _tarefaRepository.ObterTarefaAsync(idTarefa);

            if (projeto is not null && tarefa is not null)
            {
                if (projeto.Tarefas.Count() > 20)
                {
                    throw new InvalidOperationException("O projeto já possui 20 ou mais tarefas. Não é possível adicionar mais.");
                }

                projeto.Tarefas.Append(tarefa);

                await _projetoRepository.AtualizarProjetoAsync(projeto);
            }
            else
            {
                throw new InvalidOperationException("Não foi possível adicionar uma tarefa a um projeto");
            }

            return Ok("Tarefa adicionado com sucesso");
        }
    }
}
