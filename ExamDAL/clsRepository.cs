using Microsoft.EntityFrameworkCore;

namespace ExamDAL
{
    public class clsRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _dbContext;
        public clsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity Find(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public TEntity SingleOrDefault(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
