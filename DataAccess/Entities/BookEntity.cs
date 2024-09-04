using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AboutBooksDemoProject.DataAccess.Entities
{
    public class BookEntity : BaseEntity
    {
        /// <summary>
        /// Название книги
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Описание книги
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Год публикации книги
        /// </summary>
        public int? PublicationYear { get; set; }

        /// <summary>
        /// Ссылка на автора книги
        /// </summary>
        public uint? AuthorId { get; set; }
        public AuthorEntity? Author { get; set; }

        /// <summary>
        /// Категории, к которым принадлежит книга
        /// </summary>
        public ICollection<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
    }

    /// <summary>
    /// Конфигурация сущности книги (класс должен быть в отдельном файле)
    /// </summary>
    public class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.ToTable("books");

            builder.HasKey(e => e.Id)
                   .HasName("book_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnName("updated_at");

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnName("title");

            builder.Property(b => b.Description)
                   .HasColumnName("description");

            builder.Property(b => b.PublicationYear)
                   .HasColumnName("publication_year");

            builder.Property(b => b.AuthorId)
                   .HasColumnName("author_id");

            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict) 
                   .HasConstraintName("FK_book_author"); 

            builder.HasMany(b => b.Categories)
                   .WithMany(c => c.Books)
                   .UsingEntity(j => j.ToTable("books_categories"));
        }
    }
}
