using System.Globalization;
using PersonApi.DTOs;
using PersonApi.DTOs.RequestModel;
using PersonApi.DTOs.ResponseModels;
using PersonApi.Entity;
using PersonApi.Interface.Repositories;
using PersonApi.Interface.Services;

namespace PersonApi.Implementation.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

         String dateOfBirth = DateTime.Now.ToString();

        public async Task<BaseResponse> Create(CreatePersonRequestModel model)
        {
            var check = await _personRepository.GetByName(model.Name);
            if (check != null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Person already exists"
                };
            }
            if (DateTime.TryParseExact(model.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                var person = new Person
                {
                    Name = model.Name,
                    BirthDate = birthDate.ToString()
                };

                await _personRepository.CreateAsync(person);

                return new BaseResponse
                {
                    Success = true,
                    Message = "Person created successfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Invalid date format. Please provide the date in the format 'dd/MM/yyyy'."
                };
            }
        }

        public async  Task<PersonResponseModel> GetById(int id)
        {
            var person = await _personRepository.GetAsync(id);
            if (person == null)
            {
                return new PersonResponseModel
                {
                    Success = false,
                    Message = "Person not found"
                };
            }
            return new PersonResponseModel
            {
                Success = true,
                Message = "Person found",
                Data = new PersonDTO
                {
                    Name = person.Name,
                    BirthDate = person.BirthDate
                }
            };
        }

        public async Task<BaseResponse> UpdatePerson(UpdatePersonRequestModel updatedPerson)
        {
            var person = await _personRepository.GetById(updatedPerson.id);
            if (person == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Person not found"
                };
            }
            person.Name = updatedPerson.Name ?? person.Name;
            await _personRepository.UpdateAsync(person);
            return new BaseResponse
            {
                Success = true,
                Message = "Person updated successfully"
            };
        }

        public async Task<PersonResponseModel> GetByName(string name)
        {
            var person = await _personRepository.GetByName(name);
            if (person == null)
            {
                return new PersonResponseModel
                {
                    Success = false,
                    Message = "Person not found"
                };
            }
            return new PersonResponseModel
            {
                Success = true,
                Message = "Person found",
                Data = new PersonDTO
                {
                    Name = person.Name,
                    BirthDate = person.BirthDate
                }
            };
        }

        public async Task<PersonsResponseModel> GetAll()
        {
            var person = await _personRepository.GetAllAsync();
            var check = person.Where(x => x.IsDeleted == false).Select(x => new PersonDTO
            {
                Name = x.Name,
                BirthDate = x.BirthDate
            }).ToList();
            if (check == null)
            {
                return new PersonsResponseModel
                {
                    Success = false,
                    Message = "Person not found"
                };
            }
            return new PersonsResponseModel
            {
                Success = true,
                Message = "Person found",
                Data = check
            };
        }

        public async Task<BaseResponse> DeletePerson(int id)
        {
            var person = await _personRepository.GetAsync(person => person.IsDeleted == false && person.Id == id);
            if (person == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Person not found"
                };
            }
            person.IsDeleted = true;
            await _personRepository.UpdateAsync(person);
            return new BaseResponse
            {
                Success = true,
                Message = "Person deleted successfully"
            };
        }
    }
}
