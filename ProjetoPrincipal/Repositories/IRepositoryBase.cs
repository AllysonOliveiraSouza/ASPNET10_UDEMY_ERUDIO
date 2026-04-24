using ProjetoPrincipal.Models;

namespace ProjetoPrincipal.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T Create(T obj);
        T FindById(long id);
        List<T> FindAll();
        T Update(T obj);
        void Delete(long id);
        bool Exists(long id);
    }
}
