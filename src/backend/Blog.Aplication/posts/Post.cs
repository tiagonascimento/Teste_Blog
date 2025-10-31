
using Blog.Aplication.posts.interfaces;
using Blog.Aplication.service.mapster;
using Blog.Comunication.request;
using Blog.Comunication.response;
using Blog.Exception;
using Blog.Infra.Repositorio;
using Blog.Infra.Repositorio.Interfaces;
using Mapster;
using MapsterMapper;

namespace Blog.Aplication.posts
{
    public class Post : IPost
    {
        private readonly IMapper _mapper;
        private readonly IPostRepositorioWrite _postRepositorioWrite;
        private readonly IPostRepositorioRead _postRepositorioRead;
        private readonly IUnitOfWork _unitOfWork;

        public Post(IMapper mapper, IPostRepositorioWrite postRepositorio, IUnitOfWork unitOfWork, IPostRepositorioRead postRepositorioRead)
        {

            _mapper = mapper;
            MapsterConfig.Configuracao();
            _postRepositorioWrite = postRepositorio;
            _postRepositorioRead = postRepositorioRead;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CriarPost(ResquestPostJSON postJson)
        {
            var post = postJson.Adapt<Bog.Domain.entities.Post>();
            await _postRepositorioWrite.AddPost(post);
            await _unitOfWork.Commit();
            return true;
        }

        public async Task<ResponsePost> GetPosts(int idPost)
        {
            var post = await _postRepositorioRead.GetPost(idPost);
            return post.Adapt<ResponsePost>();
        }

        public async Task<List<ResponsePost>> ListaPosts()
        {
            var post = await _postRepositorioRead.GetAllPost();             
            return post.Adapt<List<ResponsePost>>();           
        }
    }
}
