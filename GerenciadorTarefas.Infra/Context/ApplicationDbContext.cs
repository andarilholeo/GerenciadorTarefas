using GerenciadorTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasOne<Projeto>(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId);
        }
    }
}