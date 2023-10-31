using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class ClubData : IClubData
    {
        private static List<Club> clubs;

        static ClubData()
        {
            clubs = new List<Club>
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
                    PartnerWithCampingId = 3
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
                    PartnerWithCampingId = 2
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
                    PartnerWithCampingId = 1
                }
            };
        }
        
        public IEnumerable<Club> GetAll()
        {
            return clubs;
        }

        public Club Get(int id)
        {
            return clubs.FirstOrDefault(x => x.Id == id);
        }

        public Club Add(Club newClub)
        {
            newClub.Id = clubs.Max(x => x.Id) + 1;
            clubs.Add(newClub);
            return newClub;
        }
    }
}