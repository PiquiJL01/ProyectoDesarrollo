using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class AdministradorDAO : DAO<Administrador>
{

    public readonly DataBaseContext _dataBaseContext;

    public AdministradorDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    } 

      
 public override IEnumerable<Administrador> Get()
    {
        throw new NotImplementedException();
    }

    public AdministradorDTO Get (string id)
    {
    var query = _dataBaseContext.Administradores
    .Where(x => x.Id == id)
    .Select(x => new AdministradorDTO
    {
        Id_Admin = x.Id,
    });
    return query.First();
    }

    public Task Add(AdministradorDTO administradorDTO)
    {
    Administrador administrador = new Administrador();
    administrador.Id = administradorDTO.Id_Admin;
    _dataBaseContext.Add(administrador);
    _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string Id_Admin)
    {
        var itemToUpdate = _dataBaseContext.Administradores.Find(Id_Admin);
        _dataBaseContext.Administradores.Remove(Id_Admin);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public override void Update(Administrador entity)
    {
        throw new NotImplementedException();
    }
}