using ProjetoPrincipal.Data.DTO;
using ProjetoPrincipal.Models;

namespace ProjetoPrincipal.Services
{
    public interface IPersonService
    {   
        PersonDTO Create(PersonDTO person);

        PersonDTO FindById(long id);

        List<PersonDTO> FindAll();

        PersonDTO Update(PersonDTO person);

        void Delete(long id);
    }
}
