using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>(todo => {
                todo.ToTable("Todo");
                todo.Property(x => x.Id);
                todo.Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
                todo.Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
                todo.Property(x => x.Done).HasColumnType("bit");
                todo.Property(x => x.Date);
                todo.HasIndex(b => b.User);
            });
        }
    }
}
