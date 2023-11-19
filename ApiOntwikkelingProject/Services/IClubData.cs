using ApiOntwikkelingProject.Entities;

namespace ApiOntwikkelingProject.Services
{
    public interface IClubData
    {
        IEnumerable<Club> GetAll();

        Club Get(int id);

        Club Add(Club newElement);

        void Delete(int id);

        void Update(Club newData);
    }
}