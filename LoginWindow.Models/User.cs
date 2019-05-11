using System;

namespace LoginWindow.Models
{
    public class User
    {
        public Guid Id { set; get; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
