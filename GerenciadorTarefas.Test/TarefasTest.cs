using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Test
{
    public class TarefaTests
    {
        [Fact]
        public void Tarefa_Constructor_ShouldSetProperties()
        {
            // Arrange
            int id = 1;
            string titulo = "Teste";
            string descricao = "Descrição de teste";
            DateTime dataVencimento = DateTime.Now.AddDays(7);
            Status status = Status.EmAndamento;
            Prioridade prioridade = Prioridade.Alta;

            // Act
            Tarefa tarefa = new Tarefa(id, titulo, descricao, dataVencimento, status, prioridade);

            // Assert
            Assert.Equal(id, tarefa.Id);
            Assert.Equal(titulo, tarefa.Titulo);
            Assert.Equal(descricao, tarefa.Descricao);
            Assert.Equal(dataVencimento, tarefa.DataVencimento);
            Assert.Equal(status, tarefa.Status);
            Assert.Equal(prioridade, tarefa.Prioridade);
        }

        [Fact]
        public void Tarefa_DefaultConstructor_ShouldSetDataCriacao()
        {
            // Arrange
            Tarefa tarefa = new Tarefa();

            // Assert
            Assert.True(tarefa.DataCriacao <= DateTime.Now);
        }

        [Fact]
        public void Tarefa_Relationships_ShouldBeSet()
        {
            // Arrange
            Projeto projeto = new Projeto { Id = 1, Nome = "Projeto de Teste" };
            Tarefa tarefa = new Tarefa { Projeto = projeto, ProjetoId = 1 };

            // Assert
            Assert.Equal(projeto, tarefa.Projeto);
            Assert.Equal(projeto.Id, tarefa.ProjetoId);
        }

        [Fact]
        public void Tarefa_DataVencimento_ShouldBeGreaterThanDataCriacao()
        {
            // Arrange
            DateTime dataCriacao = DateTime.Now;
            DateTime dataVencimento = dataCriacao.AddDays(7); // Adicionando 7 dias à data de criação
            Tarefa tarefa = new Tarefa
            {
                DataCriacao = dataCriacao,
                DataVencimento = dataVencimento
            };

            // Assert
            Assert.True(tarefa.DataVencimento > tarefa.DataCriacao);
        }
    }
}
