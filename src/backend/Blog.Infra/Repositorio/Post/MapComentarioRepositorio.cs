using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blog.Infra.Repositorio.Post
{
    public class MapComentarioRepositorio : IEntityTypeConfiguration<Bog.Domain.entities.Comentario>
    {   
        public void Configure(EntityTypeBuilder<Bog.Domain.entities.Comentario> builder)
        {
            builder.ToTable("comment");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(u => u.TxtComentario)
                   .HasColumnName("txt_comment")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.IdPost)
                   .HasColumnName("post_id")
                   .IsRequired();                


            

        }
    }
}
