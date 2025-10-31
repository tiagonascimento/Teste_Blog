using Blog.Infra.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Blog.Infra.Repositorio.Post
{
    public class ComentarioRepositorio:IComentarioRepositorioWrite, IComentarioRepositorioRead
    {
        private readonly BlogDbContext _dbContext;

        public ComentarioRepositorio(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddComentario(Bog.Domain.entities.Comentario coment)
        {
            await _dbContext.Comentarios.AddAsync(coment);
        }
        public async Task<List<Bog.Domain.entities.Comentario>> GetComentario(int idPost)
        {
            return await _dbContext.Comentarios.Where(c => c.IdPost == idPost).ToListAsync();
        }
  
    }
}

