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
            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey(t => t.ProjetoId);
        }
    }
}