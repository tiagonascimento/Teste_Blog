namespace Bog.Domain.entities
{
    public class Post : BaseEntity
    {
        private Post(){}
        public Post(string txtPost, string titulo)
        {
            TxtPost = txtPost;
            Titulo = titulo;
        }
        public string TxtPost { get; private set; }
        public string Titulo { get; private set; }
       
        public List<Comentario>Comentarios{ get; private set; }
        public void SetTxtPost(string txtPost, string titulo)
        {
            TxtPost = txtPost;
            Titulo = titulo;
        }
    }
}
