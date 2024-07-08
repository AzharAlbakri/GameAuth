using GameAuth.Entities;
using GameAuth.Entities.Models;

namespace GameAuth.SeedData
{
    public class Seed
    {
        public static User AddUser()
        {
            User user = new(new Guid(), "azhar@gamil.com", "azhar@gamil.com", "P@ssw0rd");
            return user;
        }

        public static Role AddRole()
        {
            Role role = new(new Guid(), "SuperAdmin");

            return role;
        }
    }
}
