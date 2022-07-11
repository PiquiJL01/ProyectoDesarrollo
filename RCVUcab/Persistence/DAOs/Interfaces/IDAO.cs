using System.Collections.Generic;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IDAO<T>
    {
        public List<T> Select();
        public T Select(string id);
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}