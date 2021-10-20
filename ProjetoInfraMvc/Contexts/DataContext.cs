using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using ProjetoDomain.Mvc;
using ProjetoInfraMvc.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInfraMvc.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasIndex(c => c.Matricula).IsUnique();
                entity.HasIndex(c => c.Id).IsUnique();
            });

        }
    }
}
