using System.Linq;

namespace GameAuth.Entities.Models
{
    public class User : BaseEntity
    {
        public User() { }

        public string Username { get; private set; }
        public string Email { get; private set; }

        public string Password { get; private set; }

        public List<Role> Roles { get; set; } = new();

        public User(Guid id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password; 
        }

        public void AssignRole(List<Role> role)
        {
            Roles.AddRange(role);
        }



    }
}
