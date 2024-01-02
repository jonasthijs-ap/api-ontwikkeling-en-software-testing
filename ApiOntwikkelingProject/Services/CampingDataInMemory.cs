using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class CampingDataInMemory : ICampingData
    {
        private static List<Camping> campings;

        static CampingDataInMemory()
        {
            campings = new List<Camping>
            {
                new Camping
                {
                    Id = 1,
                    Name = "Camping De Thuishaven",
                    Address = new Address
                    {
                        City = "Nieuwpoort",
                        Street = "Vismarkt",
                        HouseNumber = "2"
                    },
                    MemberedClubs = new ClubDataInMemory().GetAll().ToList().GetRange(2, 1)
                },
                new Camping
                {
                    Id = 2,
                    Name = "Camping Kempensche Bossen",
                    Address = new Address
                    {
                        City = "Lille",
                        Street = "Boskant",
                        HouseNumber = "6"
                    },
                    MemberedClubs = new ClubDataInMemory().GetAll().ToList().GetRange(1, 1)
                },
                new Camping
                {
                    Id = 3,
                    Name = "Les Trois Montagnes",
                    Address = new Address
                    {
                        City = "Durbuy",
                        Street = "Rue du Village",
                        HouseNumber = "36"
                    },
                    MemberedClubs = new ClubDataInMemory().GetAll().ToList().GetRange(0, 2)
                }
            };
        }
    
        public IEnumerable<Camping> GetAll()
        {
            return campings;
        }

        public Camping Get(int id)
        {
            return campings.FirstOrDefault(x => x.Id == id);
        }

        public Camping Add(Camping newElement)
        {
            newElement.Id = campings.Max(x => x.Id) + 1;
            campings.Add(newElement);
            return newElement;
        }

        public void Delete(int id)
        {
            Camping elementToBeDeleted = Get(id);
            campings.Remove(elementToBeDeleted);
        }

        public void Update(Camping newData)
        {
            Camping elementToBeUpdated = Get(newData.Id);
            int indexToBeUpdated = campings.IndexOf(elementToBeUpdated);

            campings[indexToBeUpdated] = newData;
        }
    }
}