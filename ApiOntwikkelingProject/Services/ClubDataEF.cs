using ApiOntwikkelingProject.DbContexts;
using ApiOntwikkelingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiOntwikkelingProject.Services
{
    public class ClubDataEF : IClubData
    {
        private readonly ApiDbContext context;

        public ClubDataEF(ApiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Club> GetAll()
        {
            return context.Clubs
                .Include(club => club.Members)
                    .ThenInclude(camper => camper.Address)
                .Include(club => club.HeadOfficeAddress)
                .ToList();
        }

        public Club Get(int id)
        {
            return context.Clubs.FirstOrDefault(obj => obj.Id == id);
        }

        public Club Add(Club newElement)
        {
            context.Clubs.Add(newElement);
            context.SaveChanges();
            return newElement;
        }

        public void Delete(int id)
        {
            Club elementToBeDeleted = Get(id);
            context.Clubs.Remove(elementToBeDeleted);
            context.SaveChanges();
        }

        public void Update(Club newData)
        {
            Club elementToBeUpdated = Get(newData.Id);
            elementToBeUpdated = newData;

            context.Update(elementToBeUpdated);
            context.SaveChanges();
        }
    }
}