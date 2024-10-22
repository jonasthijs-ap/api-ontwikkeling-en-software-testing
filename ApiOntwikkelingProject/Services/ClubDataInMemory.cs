﻿using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class ClubDataInMemory : IClubData
    {
        private static List<Club> clubs;

        static ClubDataInMemory()
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
                    Members = new CamperDataInMemory().GetAll().ToList().GetRange(0, 2)
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
                    Members = new CamperDataInMemory().GetAll().ToList().GetRange(1, 1)
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
                    Members = new CamperDataInMemory().GetAll().ToList().GetRange(0, 1)
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

        public Club Add(Club newElement)
        {
            newElement.Id = clubs.Max(x => x.Id) + 1;
            clubs.Add(newElement);
            return newElement;
        }

        public void Delete(int id)
        {
            Club elementToBeDeleted = Get(id);
            clubs.Remove(elementToBeDeleted);
        }

        public void Update(Club newData)
        {
            Club elementToBeUpdated = Get(newData.Id);
            int indexToBeUpdated = clubs.IndexOf(elementToBeUpdated);

            clubs[indexToBeUpdated] = newData;
        }
    }
}