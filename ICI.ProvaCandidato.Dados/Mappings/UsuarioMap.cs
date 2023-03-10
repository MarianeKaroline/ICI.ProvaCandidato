using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Dados.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder
                .Property(p => p.Nome)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(p => p.Senha)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Email) 
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
