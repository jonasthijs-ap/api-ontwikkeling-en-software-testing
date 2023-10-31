using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.ViewModels
{
    public class ClubCreateViewModel
    {
        public string Name { get; set; }

        public Address HeadOfficeAddress { get; set; }

        public int PartnerWithCampingId { get; set; }
    }
}