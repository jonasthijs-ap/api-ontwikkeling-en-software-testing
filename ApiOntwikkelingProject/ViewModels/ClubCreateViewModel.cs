using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;

namespace ApiOntwikkelingProject.ViewModels
{
    public class ClubCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Address HeadOfficeAddress { get; set; }

        [Required, Range(1, int.MaxValue), RegularExpression(@"^[0-9]*$")]
        public int PartnerWithCampingId { get; set; }
    }
}