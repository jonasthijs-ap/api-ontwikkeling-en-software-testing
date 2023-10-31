using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Entities
{
    public class Camper
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public int MemberFromClubId { get; set; }
    }
}