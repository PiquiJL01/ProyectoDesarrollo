using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public abstract class DAO<T> : IDAO<T>
    {
        public readonly DataBaseContext _dataBaseContext = new DesignTimeDbContextFactory().CreateDbContext(null);

        public DataBaseContext Context()
        {
            return _dataBaseContext;
        }

        public abstract List<T> Select();
        public abstract T Select(string id);

        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
    }
}