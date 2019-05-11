using LoginWindow.Services;
using System.Data.Entity;


namespace LoginWindow.DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            context.Users.Add
            (
                new Models.User
                {
                    Login = "admin",
                    Password = DataEncryptor.HashPassword("123")
                }
            );
        }
    }

}
