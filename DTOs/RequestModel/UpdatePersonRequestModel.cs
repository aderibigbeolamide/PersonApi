using System.ComponentModel.DataAnnotations;

namespace PersonApi.DTOs.RequestModel
{
    public class UpdatePersonRequestModel
    {
        public int id {get; set;}
        [Required]
        public string Name { get; set; }
    }
}
