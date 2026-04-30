using ProjetoPrincipal.Data.Converter.Implementation;
using ProjetoPrincipal.Data.DTO;
using ProjetoPrincipal.Models;
using ProjetoPrincipal.Repositories;

namespace ProjetoPrincipal.Services.Implementations
{
    public class PersonService:IPersonService
    {
        private readonly IRepositoryBase<Person> _repository;
        private readonly PersonParser _personParser;

        public PersonService(IRepositoryBase<Person> repository) { 
            _repository=repository;
            _personParser = new();
        }

        public PersonDTO Create(PersonDTO person)
        {
            var p = _personParser.Parse(person);
            return _personParser.Parse(_repository.Create(p));            
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonDTO> FindAll()
        {
            return _personParser.ParseList(_repository.FindAll());
        }

        public PersonDTO FindById(long id)
        {
            return _personParser.Parse(_repository.FindById(id));
        }

        public PersonDTO Update(PersonDTO person)
        {
            var p = _personParser.Parse(person);
            return _personParser.Parse(_repository.Update(p));
        }
    }
}
