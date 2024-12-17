
namespace ExamDAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(int id);
        List<TEntity> GetAll();
        TEntity SingleOrDefault(Func<TEntity, bool> predicate);
        void Update(TEntity entity);
    }
}