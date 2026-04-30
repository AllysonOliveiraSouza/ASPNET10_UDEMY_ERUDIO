using ProjetoPrincipal.Data.Converter.Contract;
using ProjetoPrincipal.Data.DTO;
using ProjetoPrincipal.Models;

namespace ProjetoPrincipal.Data.Converter.Implementation
{
    public class PersonParser : IParser<PersonDTO, Person>, IParser<Person,PersonDTO>
    {
        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender                
            };
        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if (origin==null) return null;
            return [..origin.Select(item => Parse(item))];
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if (origin==null) return null;
            return [.. origin.Select(item => Parse(item))];
        }

        public PersonDTO Parse(Person origin)
        {
            if (origin == null) return null;

            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }
    }
}
