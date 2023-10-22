using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class CamperData : ICamperData
    {
        private List<Camper> campers = new List<Camper>
        {
            new Camper
            {
                Id = 1,
                FirstName = "Patrick",
                LastName = "Verhulst",
                Address = new Address
                {
                    City = "Mortsel",
                    Street = "Oude God",
                    HouseNumber = "24b"
                }
            },
            new Camper
            {
                Id = 2,
                FirstName = "Jos",
                LastName = "De Haen",
                Address = new Address
                {
                    City = "Aalst",
                    Street = "Dorpstraat",
                    HouseNumber = "75"
                }
            },
            new Camper
            {
                Id = 3,
                FirstName = "Hilde",
                LastName = "Van Wilgen",
                Address = new Address
                {
                    City = "Brasschaat",
                    Street = "Miksebaan",
                    HouseNumber = "140"
                }
            }
        };

        public IEnumerable<Camper> GetAll()
        {
            return campers;
        }

        public Camper Get(int id)
        {
            return campers.FirstOrDefault(x => x.Id == id);
        }
    }
}