using ApiOntwikkelingProject.Entities;

namespace ApiOntwikkelingProject.Services
{
    public interface IClubData
    {
        IEnumerable<Club> GetAll();

        Club Get(int id);
    }
}