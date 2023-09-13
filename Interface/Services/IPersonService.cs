using PersonApi.DTOs.RequestModel;
using PersonApi.DTOs.ResponseModels;

namespace PersonApi.Interface.Services
{
    public interface IPersonService
    {
        Task<BaseResponse> Create(CreatePersonRequestModel model);
        Task<PersonResponseModel> GetById(int id);
        Task<BaseResponse> UpdatePerson(UpdatePersonRequestModel updatedPerson);
        Task<PersonResponseModel> GetByName(string name);
        Task<PersonsResponseModel> GetAll();
        Task<BaseResponse> DeletePerson(int id);
    }
}