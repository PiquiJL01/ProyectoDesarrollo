using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces;

public interface IDAO<T>
{
    public  IEnumerable<T> Select();
    public T Select(string id);
    public Task Insert(T entity);
    public Task Update(T entity);
    public Task Delete(T entity);
}