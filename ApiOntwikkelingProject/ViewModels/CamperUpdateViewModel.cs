using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOntwikkelingProject.ViewModels
{
    public class CamperUpdateViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        [Required, Range(1, int.MaxValue), ForeignKey("ClubId")]
        public int ClubId { get; set; }
    }
}