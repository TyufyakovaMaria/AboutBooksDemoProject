using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AboutBooksDemoProject.DataAccess.Entities
{
    public class AuthorEntity : BaseEntity
    {
        /// <summary>
        /// Имя автора
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Фамилия автора
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Среднее имя автора
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Год рождения автора
        /// </summary>
        public uint? BirthYear { get; set; }

        /// <summary>
        /// Полное имя автора
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Список книг, написанных данным автором
        /// </summary>
        public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
    }

    /// <summary>
    /// Конфигурация сущности автора (класс должен быть в отдельном файле)
    /// </summary>
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.ToTable("authors");

            builder.HasKey(a => a.Id)
                   .HasName("author_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnName("updated_at");

            builder.Property(a => a.FirstName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("first_name");

            builder.Property(a => a.MiddleName)
                   .HasMaxLength(50)
                   .HasColumnName("middle_name");

            builder.Property(a => a.LastName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("last_name");

            builder.Property(a => a.BirthYear)
                   .HasColumnName("birth_year");

            builder.Property(a => a.FullName)
                   .HasColumnName("full_name");
        }
    }
}
