namespace PersonApi.DTOs
{
    public class PersonDTO
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public List<PersonDTO> Phones { get; set; } = new List<PersonDTO>();
    }
}
