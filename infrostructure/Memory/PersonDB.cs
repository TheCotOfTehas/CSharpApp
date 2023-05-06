using Entities;
using Mamory;
using Microsoft.EntityFrameworkCore;

namespace Memory
{
    public class PersonDB : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildPersons(modelBuilder);
        }

        private void BuildPersons(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < 1000; i++)
            {
                var person = PersonGenerator.GetPerson();
                modelBuilder.Entity<Person>().HasData(new Person
                {
                    Id = Guid.NewGuid(),
                    Name = person.Name,
                    Surname = person.Surname,
                    Patronymic = person.Patronymic,
                    DateBirth = person.DateBirth,
                    Gender = person.Gender,
                });
            }
        }
    }
}