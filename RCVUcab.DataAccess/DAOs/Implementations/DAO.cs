/*using System.Collections.Generic;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public abstract class DAO<T> : IDAO<T>
    {
        public readonly DataBaseContext _dataBaseContext;

        public DataBaseContext Context()
        {
            return _dataBaseContext;
        }

        protected DAO(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public abstract List<T> Select();
        public abstract T Select(string id);

        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
    }
}*/