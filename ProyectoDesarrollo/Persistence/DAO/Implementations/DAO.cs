using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public abstract class DAO<T>: IDAO<T>
{
    private DataBaseContext _dataBaseContext;

    protected DAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public abstract IEnumerable<T> Get();
    public abstract T Get(string id);
    public abstract void Post(T entity);
    public abstract void Put(T entity);
    public abstract void Delete(T entity);
}