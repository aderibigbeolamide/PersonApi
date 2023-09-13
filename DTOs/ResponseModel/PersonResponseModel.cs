using PersonApi.DTOs;

namespace PersonApi.DTOs.ResponseModels
{
    public class PersonResponseModel : BaseResponse
    {
        public PersonDTO  Data {get;set;}
    }

    public class PersonsResponseModel : BaseResponse
    {
        public ICollection<PersonDTO> Data { get; set; } = new HashSet<PersonDTO>();
    }
}