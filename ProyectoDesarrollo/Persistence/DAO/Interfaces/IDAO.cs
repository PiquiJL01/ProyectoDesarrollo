using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces;

public interface IDAO<T>
{
    public  List<T> Select();
    public T Select(string id);
    public void Insert(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}