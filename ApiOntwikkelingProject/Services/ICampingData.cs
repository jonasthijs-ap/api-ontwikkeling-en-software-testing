using ApiOntwikkelingProject.Entities;

namespace ApiOntwikkelingProject.Services
{
    public interface ICampingData
    {
        IEnumerable<Camping> GetAll();

        Camping Get(int id);

        Camping Add(Camping newCamping);
    }
}