using MediatrDapper.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatrDapper.Infra.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {


            builder.ToTable("Usuario");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(e => e.Nome).HasColumnName("Nome").IsRequired().HasMaxLength(100);

            builder.Property(e => e.Codigo).HasColumnName("Codigo").IsRequired().HasMaxLength(50);

            builder.Property(e => e.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);




        }
    }
}
