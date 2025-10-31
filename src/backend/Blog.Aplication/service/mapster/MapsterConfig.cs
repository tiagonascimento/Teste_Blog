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
                .Map(dest => dest.Comments, src => src.Comentarios);



            TypeAdapterConfig<RequestCommentsJSON, Bog.Domain.entities.Comentario>
                .NewConfig()
                 .MapWith(dto => new Bog.Domain.entities.Comentario(dto.Comment, dto.IdPost));

            TypeAdapterConfig<Bog.Domain.entities.Comentario, RequestCommentsJSON>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.IdPost, src => src.IdPost)
                .Map(dest => dest.Comment, src => src.TxtComentario);

            TypeAdapterConfig<Bog.Domain.entities.Comentario, Blog.Comunication.response.ResponseComments>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Comments, src => src.TxtComentario);

            TypeAdapterConfig<Bog.Domain.entities.Post, Blog.Comunication.response.ResponsePost>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Post, src => src.TxtPost)
                .Map(dest => dest.Titulo, src => src.Titulo)
                .Map(dest=> dest.Total_comentarios, src => src.TotalComments)
                .Map(dest => dest.Comments, src => src.Comentarios);




        }
    }
}
