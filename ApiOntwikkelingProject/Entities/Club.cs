using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Entities
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address HeadOfficeAddress { get; set; }

        public List<Camper> Members { get; set; }
    }
}