using System.Collections.Generic;

namespace HomeCrud.Entities
{
    public class Home : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Person> People { get; } = new List<Person>();
    }
}