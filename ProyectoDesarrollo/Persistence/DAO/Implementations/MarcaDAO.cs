using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;


namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class MarcaDAO: DAO<Marca>
{
    public readonly DataBaseContext _dataBaseContext;

    public MarcaDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Marca> Get()
    {
        throw new NotImplementedException();
    }

    public MarcaDTO GetMarca(string Name)
    {
        var query =_dataBaseContext.Marcas
            .Where(m => m.Name == Name)
            .Select(m => new MarcaDTO 
            { 
                Name = m.Name 
            });
        return query.First();

    }

    public Task Add(MarcaDTO marcaDTO)
    {
        Marca marca =  new Marca();
        marca.Name = marcaDTO.Name;
        _dataBaseContext.Marcas.Add(marca);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Update (MarcaDTO marcaDTO,string Name)
    {
        var itemToUpdate = _dataBaseContext.Marcas.Find(Name);
        itemToUpdate.Name = marcaDTO.Name;
        _dataBaseContext.SaveChanges();

        return Task.CompletedTask;
    }

    public Task Delete(string Name)
    {
        var ItemToRemove = _dataBaseContext.Marcas.Find(Name);
        _dataBaseContext.Marcas.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}