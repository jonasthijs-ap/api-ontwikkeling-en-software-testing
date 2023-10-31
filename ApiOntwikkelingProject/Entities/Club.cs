using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Entities
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address HeadOfficeAddress { get; set; }

        public int PartnerWithCampingId { get; set; }
    }
}