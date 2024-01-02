using ApiOntwikkelingProject.DbContexts;
using ApiOntwikkelingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiOntwikkelingProject.Services
{
    public class CampingDataEF : ICampingData
    {
        private readonly ApiDbContext context;

        public CampingDataEF(ApiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Camping> GetAll()
        {
            return context.Campings
                .Include(camping => camping.MemberedClubs)
                    .ThenInclude(club => club.Members)
                        .ThenInclude(camper => camper.Address)
                .Include(camping => camping.MemberedClubs)
                    .ThenInclude(club => club.HeadOfficeAddress)
                .Include(camping => camping.Address)
                .ToList();
        }

        public Camping Get(int id)
        {
            return context.Campings.FirstOrDefault(obj => obj.Id == id);
        }

        public Camping Add(Camping newElement)
        {
            context.Campings.Add(newElement);
            context.SaveChanges();
            return newElement;
        }

        public void Delete(int id)
        {
            Camping elementToBeDeleted = Get(id);
            context.Campings.Remove(elementToBeDeleted);
            context.SaveChanges();
        }

        public void Update(Camping newData)
        {
            Camping elementToBeUpdated = Get(newData.Id);
            elementToBeUpdated = newData;

            context.Update(elementToBeUpdated);
            context.SaveChanges();
        }
    }
}