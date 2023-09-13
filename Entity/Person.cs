using PersonApi.Contracts;

namespace PersonApi.Entity
{
    public class Person : AuditableEntity
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}