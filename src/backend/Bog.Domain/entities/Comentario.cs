

namespace Bog.Domain.entities
{
    public class Comentario:BaseEntity
    {
        private Comentario() { }
        public Comentario(string txtComentario, int IDPost)
        {
            TxtComentario = txtComentario;
            IdPost = IDPost;
        }
        public string TxtComentario { get; private set; }
        public int IdPost { get; private set; }
        public Post Post { get; private set; }

        public void SetTxtComentario(string txtPost, int IDPost)
        {
            TxtComentario = txtPost;
            IdPost = IDPost;
        }
    }
}
