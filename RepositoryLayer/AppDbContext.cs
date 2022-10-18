
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Configuration;
using ToDoList.Core.Model;

namespace RepositoryLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new NoteConfiguration());


            builder.Entity<UserRole>().HasData(new UserRole { Id = 1, Name = "Admin", }
            , new UserRole { Id = 2, Name = "User", });


        }

    }
}
