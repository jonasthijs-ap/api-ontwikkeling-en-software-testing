﻿using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;

namespace ApiOntwikkelingProject.Services
{
    public class CampingData : ICampingData
    {
        private List<Camping> campings = new List<Camping>
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
                Partners = new List<Club>
                {
                    new ClubData().Get(1),
                    new ClubData().Get(2),
                    new ClubData().Get(3)
                }
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
                Partners = new List<Club>
                {
                    new ClubData().Get(1),
                    new ClubData().Get(2)
                }
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
                Partners = new List<Club>
                {
                    new ClubData().Get(1)
                }
            }
        };

        public IEnumerable<Camping> GetAll()
        {
            return campings;
        }

        public Camping Get(int id)
        {
            return campings.FirstOrDefault(x => x.Id == id);
        }
    }
}