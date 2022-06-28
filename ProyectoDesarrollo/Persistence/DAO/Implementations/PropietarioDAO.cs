using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;


namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PropietarioDAO: DAO<Propietario>
{
    public readonly DataBaseContext _dataBaseContext;

    public PropietarioDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Propietario> Get()
    {
        throw new NotImplementedException();
    }

    public override PropietarioDTO GetPropietario(string CedulaRif)
    {
        var query = _dataBaseContext.Propietarios
            .Where(x => x.CedulaRif == CedulaRif)
            .Select(x => new PropietarioDTO
            {
                CedulaRif = x.CedulaRif,
                PrimerNombre = x.PrimerNombre,
                SegundoNombre = x.SegundoNombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido,
                FechaNacimiento = x.FechaNacimiento,
                Direccion = x.Direccion,
                Id_Poliza = x.Id_Poliza
            });
        return query.First();
    }

    public Task Add(PropietarioDTO propietarioDTO)
    {
        Propietario propietario = new Propietario();
        propietario.CedulaRif = propietarioDTO.CedulaRif;
        propietario.PrimerNombre = propietarioDTO.PrimerNombre;
        propietario.SegundoNombre= propietarioDTO.SegundoNombre;
        propietario.PrimerApellido= propietarioDTO.PrimerApellido;
        propietario.SegundoApellido= propietarioDTO.SegundoApellido;
        propietario.FechaNacimiento= propietarioDTO.FechaNacimiento;
        propietario.Direccion= propietarioDTO.Direccion;
        propietario.Id_Poliza= propietarioDTO.Id_Poliza;
        _dataBaseContext.Propietarios.Add(propietario);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task  Update(PropietarioDTO  propietarioDTO,string  CedulaRif)
    {
        var ItemToUpdate = _dataBaseContext.Propietarios.Find(CedulaRif);
        ItemToUpdate.PrimerNombre= propietarioDTO.PrimerNombre;
        ItemToUpdate.SegundoNombre= propietarioDTO.SegundoNombre;
        ItemToUpdate.PrimerApellido = propietarioDTO.PrimerApellido;
        ItemToUpdate.SegundoApellido = propietarioDTO.SegundoApellido;
        ItemToUpdate.Direccion = propietarioDTO.Direccion;
        ItemToUpdate.Id_Poliza = propietarioDTO.Id_Poliza;
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string CedulaRif)
    {
        var ItemToRemove = _dataBaseContext.Propietarios.Find(CedulaRif);
        _dataBaseContext.Propietarios.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}