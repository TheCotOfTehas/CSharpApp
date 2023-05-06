using Entities;

namespace Mamory
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateBirth { get; set; }

    }
}