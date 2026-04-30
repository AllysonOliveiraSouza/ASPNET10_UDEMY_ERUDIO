using ProjetoPrincipal.Data.DTO;
using ProjetoPrincipal.Models;

namespace ProjetoPrincipal.Services
{
    public interface IBookService
    {
        BookDTO Create(BookDTO book);

        BookDTO FindById(long id);

        List<BookDTO> FindAll();

        BookDTO Update(BookDTO book);

        void Delete(long id);
    }
}
