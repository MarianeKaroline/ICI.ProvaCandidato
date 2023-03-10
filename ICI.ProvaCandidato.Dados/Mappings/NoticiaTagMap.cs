using ICI.ProvaCandidato.Dados.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Dados.Mappings
{
    internal class NoticiaTagMap : IEntityTypeConfiguration<NoticiaTag>
    {
        public void Configure(EntityTypeBuilder<NoticiaTag> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Tag)
                .WithMany(p => p.NoticiaTags)
                .HasForeignKey(p => p.TagId);

            builder
                .HasOne(p => p.Noticia)
                .WithMany(p => p.NoticiaTags)
                .HasForeignKey(p => p.NoticiaId);
        }
    }
}
