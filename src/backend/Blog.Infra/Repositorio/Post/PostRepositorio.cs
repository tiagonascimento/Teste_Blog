using Blog.Infra.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Repositorio.Post
{
    public class PostRepositorio:IPostRepositorioWrite, IPostRepositorioRead
    {
        private readonly BlogDbContext _dbContext;

        public PostRepositorio(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddPost(Bog.Domain.entities.Post post)
        {
            await _dbContext.Posts.AddAsync(post);
        }
        public async Task<Bog.Domain.entities.Post> GetPost(int id)
        {
            return await _dbContext.Posts
                .Include(p => p.Comentarios)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<Bog.Domain.entities.Post>> GetAllPost()
        {

           return await _dbContext.Posts
                       .Include(p => p.Comentarios)
                      .ToListAsync();



        }
    }
}
