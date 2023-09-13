using PersonApi.Context;
using PersonApi.DTOs.ResponseModels;
using PersonApi.Entity;
using PersonApi.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PersonApi.Implementations.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        public Task<Person> GetById(int id)
        {
            var person = _Context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }
        public Task<Person> GetByName(string name)
        {
            var person = _Context.Persons.FirstOrDefaultAsync(x => x.Name == name);
            return person;
        }
    }
}
