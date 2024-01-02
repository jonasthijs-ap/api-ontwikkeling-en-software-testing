using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOntwikkelingProject.ViewModels
{
    public class ClubCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Address HeadOfficeAddress { get; set; }

        [Required, Range(1, int.MaxValue), ForeignKey("CampingId")]
        public int CampingId { get; set; }
    }
}