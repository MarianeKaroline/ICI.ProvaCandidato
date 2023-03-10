using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Dados.Mappings
{
    public class NoticiaMap : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();
               
            builder
                .Property(p => p.Titulo)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(p => p.Texto)
                .HasColumnType("text")
                .IsRequired();

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Noticias)
                .HasForeignKey(p => p.UsuarioId);
        }
    }
}
