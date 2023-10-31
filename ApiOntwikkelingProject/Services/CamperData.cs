using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class CamperData : ICamperData
    {
        private static List<Camper> campers;

        static CamperData()
        {
            campers = new List<Camper>
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
                    },
                    MemberFromClubId = 1
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
                    },
                    MemberFromClubId = 3
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
                    },
                    MemberFromClubId = 2
                }
            };
        }
        
        public IEnumerable<Camper> GetAll()
        {
            return campers;
        }

        public Camper Get(int id)
        {
            return campers.FirstOrDefault(x => x.Id == id);
        }

        public Camper Add(Camper newCamper)
        {
            newCamper.Id = campers.Max(x => x.Id) + 1;
            campers.Add(newCamper);
            return newCamper;
        }
    }
}