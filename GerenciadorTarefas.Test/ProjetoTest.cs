using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Test
{
    public class ProjetoTest
    {
        [Fact]
        public void Projeto_Constructor_Sets_IdAndNome()
        {
            // Arrange
            int expectedId = 42;
            string expectedNome = "Meu Projeto";

            // Act
            var projeto = new Projeto(expectedId, expectedNome);

            // Assert
            Assert.Equal(expectedId, projeto.Id);
            Assert.Equal(expectedNome, projeto.Nome);
        }

        [Fact]
        public void Projeto_Properties_WorkCorrectly()
        {
            // Arrange
            var projeto = new Projeto();

            // Act
            projeto.Id = 10;
            projeto.Nome = "Novo Projeto";

            // Assert
            Assert.Equal(10, projeto.Id);
            Assert.Equal("Novo Projeto", projeto.Nome);
        }

        [Fact]
        public void Projeto_Tarefas_CanBeNull()
        {
            // Arrange
            var projeto = new Projeto();

            // Act
            projeto.Tarefas = null;

            // Assert
            Assert.Null(projeto.Tarefas);
        }

        [Fact]
        public void Projeto_Tarefas_CanBeEmpty()
        {
            // Arrange
            var projeto = new Projeto();

            // Act
            projeto.Tarefas = new List<Tarefa>();

            // Assert
            Assert.Empty(projeto.Tarefas);
        }
    }
}
