using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;

namespace ApiOntwikkelingProject.ViewModels
{
    public class CamperUpdateViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }
    }
}