using System.Collections.Generic;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces;

public interface IDAO<T>
{
    public  IEnumerable<T> Get();
    public T Get(string id);
    public void Post(T entity);
    public void Put(T entity);
    public void Delete(T entity);
}