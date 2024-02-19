using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Infra.Context;
using GerenciadorTarefas.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Test.InfraTest
{
    public class ProjetoRepositoryTest
    {
        [Fact]
        public async Task ObterTodosProjetosDoUsuario_ReturnsCorrectProjects()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new ProjetoRepository(context);
                var expectedProjects = new List<Projeto>
        {
            new Projeto { Id = 1, Nome = "Projeto A" },
            new Projeto { Id = 2, Nome = "Projeto B" }
        };

                context.Projetos.AddRange(expectedProjects);
                await context.SaveChangesAsync();

                // Act
                var result = await repository.ObterTodosProjetosDoUsuario();

                // Assert
                Assert.Equal(expectedProjects.Count, result.Count());
                Assert.All(expectedProjects, p => result.Any(r => r.Id == p.Id && r.Nome == p.Nome));
            }
        }

        [Fact]
        public async Task ObterProjeto_ReturnsCorrectProjectById()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new ProjetoRepository(context);
                var expectedProject = new Projeto { Id = 12, Nome = "Projeto A" };

                context.Projetos.Add(expectedProject);
                await context.SaveChangesAsync();

                // Act
                var result = await repository.ObterProjeto(1);

                // Assert
                Assert.Equal(expectedProject.Id, result.Id);
                Assert.Equal(expectedProject.Nome, result.Nome);
            }
        }

        [Fact]
        public async Task CriarProjetoAsync_AddsNewProject()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new ProjetoRepository(context);
                var newProject = new Projeto { Id = 3, Nome = "Projeto C" };

                // Act
                await repository.CriarProjetoAsync(newProject);

                // Assert
                var result = await context.Projetos.FindAsync(3);
                Assert.NotNull(result);
                Assert.Equal(newProject.Nome, result.Nome);
            }
        }

        [Fact]
        public async Task DeletarProjetoAsync_RemovesProject()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new ProjetoRepository(context);
                var projectToDelete = new Projeto { Id = 2, Nome = "Projeto B" };

                context.Projetos.Add(projectToDelete);
                await context.SaveChangesAsync();

                // Act
                await repository.DeletarProjetoAsync(2);

                // Assert
                var result = await context.Projetos.FindAsync(2);
                Assert.Null(result);
            }
        }
    }
}
