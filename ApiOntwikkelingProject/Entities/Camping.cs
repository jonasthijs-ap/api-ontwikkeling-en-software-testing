using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;

namespace ApiOntwikkelingProject.Entities
{
    public class Camping
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Club> MemberedClubs { get; set; }
    }
}