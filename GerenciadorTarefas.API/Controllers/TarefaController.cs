using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterTarefasProjeto(int? idProjeto)
        {
            var tarefas = await _tarefaRepository.ObterTodasTarefasDoProjetoAsync(idProjeto);

            if (tarefas is null)
                return NotFound("Tarefas não encontradas");

            return Ok(tarefas);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterTarefas()
        {
            var tarefas = await _tarefaRepository.ObterTodasAsTarefas();

            if (tarefas is null)
                return NotFound("Tarefas não encontradas");

            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult> CriarTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa is null)
                return BadRequest("Invalid Data");

            await _tarefaRepository.CriarTarefaAsync(tarefa);

            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest();

            await _tarefaRepository.AtualizarTarefaAsync(tarefa);
            return Ok(tarefa);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletarTarefa(int id)
        {
            var tarefa = await _tarefaRepository.ObterTarefaAsync(id);
            if (tarefa is null)
                return BadRequest();

            await _tarefaRepository.RemoverTarefa(id);
            return Ok();
        }
    }
}
