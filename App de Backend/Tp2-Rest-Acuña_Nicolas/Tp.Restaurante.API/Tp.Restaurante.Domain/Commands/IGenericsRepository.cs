namespace Tp.Restaurante.Domain.Commands
{
    public interface IGenericsRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        T Exists<T>(int id) where T : class;
    }
}
