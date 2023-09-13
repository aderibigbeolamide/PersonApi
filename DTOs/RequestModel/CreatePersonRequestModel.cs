using System.ComponentModel.DataAnnotations;

namespace PersonApi.DTOs.RequestModel
{
    public class CreatePersonRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string BirthDate { get; set; }
    }

    public class GetPersonRequestModel
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        
    }
}
