using ProjetoPrincipal.Data.DTO.V1;
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
