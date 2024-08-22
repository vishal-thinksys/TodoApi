using Microsoft.EntityFrameworkCore;
using Todo.Api.Models;

namespace Todo.Api.Contexts
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
