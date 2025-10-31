using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blog.Infra.Repositorio.Post
{
    public class MapPostRepositorio : IEntityTypeConfiguration<Bog.Domain.entities.Post>
    {
        public void Configure(EntityTypeBuilder<Bog.Domain.entities.Post> builder)
        {
            builder.ToTable("posts");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .HasColumnName("idposts")
                   .IsRequired();
                
                   
            builder.Property(u => u.TxtPost)
                   .HasColumnName("txtPost")
                   .IsRequired()
                   .HasMaxLength(255);
          
            // Relacionamento: Post tem muitos Comentarios
            builder.HasMany(p => p.Comentarios)
                   .WithOne(c => c.Post)
                   .HasForeignKey(c => c.IdPost)
                   .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
