using CodeBuddies.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Data
{
    public class CodeBuddiesContext : DbContext
    {
        public CodeBuddiesContext(DbContextOptions<CodeBuddiesContext> options)
            : base(options) { }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<FaseJogo> FasesJogo { get; set; }
        public DbSet<Progresso> Progressos { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ranking>()
                .HasIndex(r => r.AlunoId)
                .IsUnique();

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Alunos)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aluno>()
                .HasMany(a => a.Progressos)
                .WithOne(p => p.Aluno)
                .HasForeignKey(p => p.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FaseJogo>()
                .HasMany(f => f.Progressos)
                .WithOne(p => p.FaseJogo)
                .HasForeignKey(p => p.FaseJogoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Ranking)
                .WithOne(r => r.Aluno)
                .HasForeignKey<Ranking>(r => r.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
