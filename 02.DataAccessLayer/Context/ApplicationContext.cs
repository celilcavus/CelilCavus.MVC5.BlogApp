using _01.EntityLayer;
using System.Data.Entity;

namespace _02.DataAccessLayer.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }
    }
}
