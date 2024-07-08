namespace GameAuth.Entities.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }


        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
