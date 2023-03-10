using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados
{
	public class Context : DbContext
	{
		public Context() { }
		public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }

		public DbSet<Noticia> Noticia { get; set; }
		public DbSet<NoticiaTag> NoticiaTag { get; set; }
		public DbSet<Tag> Tag { get; set; }
		public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new UsuarioMap());
			modelBuilder.ApplyConfiguration(new NoticiaMap());
			modelBuilder.ApplyConfiguration(new TagMap());
			modelBuilder.ApplyConfiguration(new NoticiaTagMap());

			base.OnModelCreating(modelBuilder);
        }
    }
}
