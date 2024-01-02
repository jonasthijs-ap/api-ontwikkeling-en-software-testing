using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required, Range(1, int.MaxValue), ForeignKey("ClubId")]
        public int ClubId { get; set; }
    }
}