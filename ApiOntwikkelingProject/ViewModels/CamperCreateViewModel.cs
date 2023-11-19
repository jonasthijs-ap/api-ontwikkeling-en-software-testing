using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;

namespace ApiOntwikkelingProject.ViewModels
{
    public class CamperCreateViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required, Range(1, int.MaxValue), RegularExpression(@"^[0-9]*$")]
        public int MemberFromClubId { get; set; }
    }
}