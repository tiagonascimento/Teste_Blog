
using Blog.Infra.Repositorio.Interfaces;

namespace Blog.Infra.Repositorio
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BlogDbContext _dbcontex;
        public UnitOfWork(BlogDbContext dbContex) => _dbcontex = dbContex;

        public async Task Commit() => await _dbcontex.SaveChangesAsync();
    }
}
