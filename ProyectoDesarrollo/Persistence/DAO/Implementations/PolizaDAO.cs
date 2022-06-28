using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PolizaDAO: DAO<Poliza>
{
    public readonly DataBaseContext _dataBaseContext;

    public PolizaDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Poliza> Get()
    {
        throw new NotImplementedException();
    }

    public PolizaDTO GetPoliza(string ID)
    {
        var query = _dataBaseContext.Polizas
            .Where(p => p.ID == ID)
            .Select(p => new PolizaDTO
            {
                ID = p.ID,
                Id_Admin = p.Id_Admin,
                TipoPoliza = (PolizaDTO.Tipo)p.TipoPoliza
            });
        return query.First();

    }

    public Task Add(PolizaDTO  polizaDTO)
    {
        Poliza poliza = new Poliza();
        poliza.ID = polizaDTO.ID;
        poliza.Id_Admin = polizaDTO.Id_Admin;
        poliza.TipoPoliza = (Poliza.Tipo)polizaDTO.TipoPoliza;
        _dataBaseContext.Polizas.Add(poliza);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;  
    }

    public Task Update(PolizaDTO polizaDTO,string ID)
    {
        var ItemToUpdate = _dataBaseContext.Polizas.Find(ID);
        ItemToUpdate.ID = polizaDTO.ID;
        ItemToUpdate.Id_Admin = polizaDTO.Id_Admin;
        ItemToUpdate.TipoPoliza = (Poliza.Tipo)polizaDTO.TipoPoliza;
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string ID)
    {
       var  ItemToRemove  = _dataBaseContext.Polizas.Find(ID);
        ItemToRemove.Polizas.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
            }
}