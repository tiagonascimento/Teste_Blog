using Blog.Infra.Repositorio.Post;
using Microsoft.EntityFrameworkCore;


namespace Blog.Infra.Repositorio
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Bog.Domain.entities.Post> Posts { get; set; }
        public DbSet<Bog.Domain.entities.Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostRepositorio).Assembly);
           base.OnModelCreating(modelBuilder);
        }
    }
}
