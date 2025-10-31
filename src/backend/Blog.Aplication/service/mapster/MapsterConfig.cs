using Blog.Comunication.request;
using Mapster;


namespace Blog.Aplication.service.mapster
{
    static public class MapsterConfig
    {
        public static void Configuracao()
        {
            // Configuração para PostJson -> Post
            TypeAdapterConfig<ResquestPostJSON, Bog.Domain.entities.Post>
                .NewConfig()
                .MapWith(dto => new Bog.Domain.entities.Post(dto.PostJson, dto.Titulo));

            // Configuração para post -> PostJson
            TypeAdapterConfig<Bog.Domain.entities.Post, ResquestPostJSON>
                .NewConfig()
                .Map(dest => dest.PostJson, src => src.TxtPost)
                .Map(dest => dest.Titulo, src => src.Titulo)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Comments, src => src.Comentarios.Adapt<List<Bog.Domain.entities.Comentario>>());


            TypeAdapterConfig<RequestCommentsJSON, Bog.Domain.entities.Comentario>
                .NewConfig()
                 .MapWith(dto => new Bog.Domain.entities.Comentario(dto.Comment, dto.IdPost));

            TypeAdapterConfig<Bog.Domain.entities.Comentario, RequestCommentsJSON>
                .NewConfig()
                .Map(dest => dest.Comment, src => src.TxtComentario)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.IdPost, src => src.IdPost);

        }
    }
}
