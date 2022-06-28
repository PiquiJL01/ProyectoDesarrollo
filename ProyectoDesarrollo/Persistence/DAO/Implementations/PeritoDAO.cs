using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PeritoDAO: DAO<Perito>
{
    public readonly DataBaseContext _dataBaseContext;

    public PeritoDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Perito> Get()
    {
        throw new NotImplementedException();
    }

    public PeritoDTO GetPerito(string Id_Perito)
    {
        var query = _dataBaseContext.Peritos
            .Where(p => p.Id == Id_Perito)
            .Select(p => new PeritoDTO
            {
                Id_Perito = p.Id_Perito           
            });
        return query.First();

    }

    public Task Add(PeritoDTO peritoDTO)
    {
        Perito  perito = new Perito();
        perito.Id_Perito = peritoDTO.Id_Perito;
        _dataBaseContext.Peritos.Add(perito);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Update(PeritoDTO peritoDTO, string Id_Perito)
    {
        var ItemToUpdate = _dataBaseContext.Peritos.Find(Id_Perito);
        ItemToUpdate.Id_Perito = peritoDTO.Id_Perito;
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string Id_Perito)
    {
        var ItemToRemove  = _dataBaseContext.Peritos.Find(Id_Perito);
        _dataBaseContext.Peritos.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}