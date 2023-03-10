using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Repositories;
using System;

namespace ICI.ProvaCandidato.Dados
{
    public class UnitOfWork : IDisposable
    {
        private readonly Context _context;

        private Repository<Noticia> noticiaRepository;
        private Repository<Usuario> usuarioRepository;
        private Repository<Tag> tagRepository;
        private Repository<NoticiaTag> noticiaTagRepository;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public Repository<Noticia> NoticiaRepository
        {
            get
            {
                this.noticiaRepository ??= new Repository<Noticia>(_context);
                return noticiaRepository;
            }
        }

        public Repository<Usuario> UsuarioRepository
        {
            get
            {
                this.usuarioRepository ??= new Repository<Usuario>(_context);
                return usuarioRepository;
            }
        }

        public Repository<Tag> TagRepository
        {
            get
            {
                this.tagRepository ??= new Repository<Tag>(_context);
                return tagRepository;
            }
        }

        public Repository<NoticiaTag> NoticiaTagRepository
        {
            get
            {
                this.noticiaTagRepository ??= new Repository<NoticiaTag>(_context);
                return noticiaTagRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}
