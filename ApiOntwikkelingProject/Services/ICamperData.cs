using ApiOntwikkelingProject.Entities;

namespace ApiOntwikkelingProject.Services
{
    public interface ICamperData
    {
        IEnumerable<Camper> GetAll();

        Camper Get(int id);

        Camper Add(Camper newElement);

        void Delete(int id);

        void Update(Camper newData);
    }
}