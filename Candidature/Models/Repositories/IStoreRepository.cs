namespace Candidature.Models.Repositories
{
    public interface IStoreRepository<T>
    {
        IList<T> GetAll();
        T Find(int id);
        void Add(T t);
        void Update(T t);
        void Delete(int id);


    }
}
