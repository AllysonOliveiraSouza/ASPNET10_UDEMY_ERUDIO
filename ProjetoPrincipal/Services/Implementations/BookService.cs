using ProjetoPrincipal.Models;
using ProjetoPrincipal.Repositories;

namespace ProjetoPrincipal.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepositoryBase<Book> _repository;

        public BookService(IRepositoryBase<Book> repository) { 
            _repository = repository;
        }
        public Book Create(Book person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
           return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book person)
        {
            return _repository.Update(person);
        }
    }
}
