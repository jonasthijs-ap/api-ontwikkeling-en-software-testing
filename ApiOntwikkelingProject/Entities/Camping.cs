using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Entities
{
    public class Camping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}