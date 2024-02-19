using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Infra.Context;
using GerenciadorTarefas.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Test.InfraTest
{
    public class TarefaRepositoryTest
    {
        [Fact]
        public async Task CriarTarefaAsync_AddsNewTask()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new TarefaRepository(context);
                var newTask = new Tarefa { Id = 3, Titulo = "Tarefa C", Descricao = "Teste Tarefa C DESCRICAO" };

                // Act
                await repository.CriarTarefaAsync(newTask);

                // Assert
                var result = await context.Tarefas.FindAsync(3);
                Assert.NotNull(result);
                Assert.Equal(newTask.Titulo, result.Titulo);
            }
        }

        [Fact]
        public async Task CriarTarefaAsync_NonExistingId_Succeeds()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new TarefaRepository(context);
                var newTask = new Tarefa { Id = 6, Titulo = "Tarefa E", Descricao = "Teste Tarefa E DESCRICAO" };

                // Act
                await repository.CriarTarefaAsync(newTask);

                // Assert
                var result = await context.Tarefas.FindAsync(6);
                Assert.NotNull(result);
                Assert.Equal(newTask.Titulo, result.Titulo);
            }
        }
    }
}
