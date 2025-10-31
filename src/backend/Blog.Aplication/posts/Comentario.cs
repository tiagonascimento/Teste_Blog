using Blog.Aplication.posts.interfaces;
using Blog.Aplication.service.mapster;
using Blog.Comunication.request;
using Blog.Infra.Repositorio.Interfaces;
using Bog.Domain.entities;
using Mapster;
using MapsterMapper;

namespace Blog.Aplication.posts
{
    public  class Comentario : IComentario
    {
        private readonly IMapper _mapper;
        private readonly IPostRepositorioWrite _postRepositorioWrite;
        private readonly IComentarioRepositorioWrite _ComentatioRepositorioWrite;
        private readonly IUnitOfWork _unitOfWork;


        public Comentario(IMapper mapper, IPostRepositorioWrite postRepositorio, IUnitOfWork unitOfWork, IComentarioRepositorioWrite ComentatioRepositorioWrite)
        {
            _mapper = mapper;
            MapsterConfig.Configuracao();
            _postRepositorioWrite = postRepositorio;
            _ComentatioRepositorioWrite = ComentatioRepositorioWrite;
            
            _unitOfWork = unitOfWork;
        }
        
        public async Task<bool> CriarComentario(RequestCommentsJSON comentarioJson)
        {
            var coment = comentarioJson.Adapt<Bog.Domain.entities.Comentario>();
           

            await _ComentatioRepositorioWrite.AddComentario(coment);
            await _unitOfWork.Commit();
            return true;           
        }
    }
}
