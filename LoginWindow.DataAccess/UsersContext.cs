namespace LoginWindow.DataAccess
{
    using LoginWindow.Models;
    using System.Data.Entity;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}