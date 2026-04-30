using Mapster;
using ProjetoPrincipal.Data.DTO;
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
        public BookDTO Create(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            _repository.Create(entity);
            return entity.Adapt<BookDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookDTO> FindAll()
        {
           return _repository.FindAll().Adapt<List<BookDTO>>();
        }

        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }

        public BookDTO Update(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            _repository.Update(entity);

            return entity.Adapt<BookDTO>();
        }
    }
}
