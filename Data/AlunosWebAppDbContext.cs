using AlunosWebApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlunosWebApp.Data
{
    public class AlunosWebAppDbContext : DbContext

    {
        public AlunosWebAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Aluno> Alunos { get; set; }    
    }
}
