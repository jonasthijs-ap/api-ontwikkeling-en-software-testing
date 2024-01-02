using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOntwikkelingProject.ViewModels
{
    public class ClubUpdateViewModel
    {
        public string Name { get; set; }

        public Address HeadOfficeAddress { get; set; }

        [Required, Range(1, int.MaxValue), ForeignKey("CampingId")]
        public int CampingId { get; set; }
    }
}