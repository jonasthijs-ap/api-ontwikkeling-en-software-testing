using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.ViewModels
{
    public class CamperCreateViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public int MemberFromClubId { get; set; }
    }
}