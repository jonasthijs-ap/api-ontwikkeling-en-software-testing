using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class ClubData : IClubData
    {
        private List<Club> clubs = new List<Club>
        {
            new Club
            {
                Id = 1,
                Name = "Pasar Stad en Rand Antwerpen",
                HeadOfficeAddress = new Address
                {
                    City = "Antwerpen",
                    Street = "Grote Markt",
                    HouseNumber = "18"
                },
                Members = new List<Camper>
                {
                    new CamperData().Get(1),
                    new CamperData().Get(2)
                }
            },
            new Club
            {
                Id = 2,
                Name = "Kampeerclub De Vogel",
                HeadOfficeAddress = new Address
                {
                    City = "Arendonk",
                    Street = "Veldhoflaan",
                    HouseNumber = "52"
                },
                Members = new List<Camper>
                {
                    new CamperData().Get(3)
                }
            },
            new Club
            {
                Id = 3,
                Name = "Pasar Zelzate-Gent",
                HeadOfficeAddress = new Address
                {
                    City = "Gent",
                    Street = "Waterpoortstraat",
                    HouseNumber = "124a"
                },
                Members = new List<Camper>
                {
                    new CamperData().Get(2),
                    new CamperData().Get(3)
                }
            }
        };

        public IEnumerable<Club> GetAll()
        {
            return clubs;
        }

        public Club Get(int id)
        {
            return clubs.FirstOrDefault(x => x.Id == id);
        }
    }
}