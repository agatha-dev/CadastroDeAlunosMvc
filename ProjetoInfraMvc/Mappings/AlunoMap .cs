using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDomain.Mvc;

namespace ProjetoInfraMvc.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Matricula)
                .HasColumnName("Matricula")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
               .HasColumnName("DataNascimento")
               .HasMaxLength(100)
               .IsRequired();
        }
    }
}
