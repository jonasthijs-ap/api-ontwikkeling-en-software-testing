using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOntwikkelingProject.Entities
{
    public class Club
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Address HeadOfficeAddress { get; set; }

        public List<Camper> Members { get; set; }

        [ForeignKey("CampingId")]
        public int CampingId { get; set; }
    }
}