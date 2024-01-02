using ApiOntwikkelingProject.DbContexts;
using ApiOntwikkelingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiOntwikkelingProject.Services
{
    public class CamperDataEF : ICamperData
    {
        private readonly ApiDbContext context;

        public CamperDataEF(ApiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Camper> GetAll()
        {
            return context.Campers
                .Include(camper => camper.Address)
                .ToList();
        }

        public Camper Get(int id)
        {
            return context.Campers.FirstOrDefault(obj => obj.Id == id);
        }

        public Camper Add(Camper newElement)
        {
            context.Campers.Add(newElement);
            context.SaveChanges();
            return newElement;
        }

        public void Delete(int id)
        {
            Camper elementToBeDeleted = Get(id);
            context.Campers.Remove(elementToBeDeleted);
            context.SaveChanges();
        }

        public void Update(Camper newData)
        {
            Camper elementToBeUpdated = Get(newData.Id);
            elementToBeUpdated = newData;

            context.Update(elementToBeUpdated);
            context.SaveChanges();
        }
    }
}