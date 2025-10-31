using Blog.Comunication.request;
using Blog.Comunication.response;



namespace Blog.Aplication.posts.interfaces
{
    public interface IPost
    {
        public Task<bool> CriarPost(ResquestPostJSON post);
        public Task<List<ResponsePost>> ListaPosts();

        public Task<ResponsePost> GetPosts(int idPost);
    }
}
