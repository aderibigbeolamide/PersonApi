using PersonApi.DTOs.ResponseModels;
using PersonApi.Entity;

namespace PersonApi.Interface.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person> GetById(int id);
        Task<Person> GetByName(string name);
    }
}

