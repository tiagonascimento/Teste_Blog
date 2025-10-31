
namespace Blog.Infra.Repositorio.Interfaces
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
