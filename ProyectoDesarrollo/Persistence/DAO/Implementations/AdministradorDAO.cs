using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.Data;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class AdministradorDAO : DAO<AdministradorDTO>, IAdministradorDAO
{

    public AdministradorDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    } 

      
    public override List<AdministradorDTO> Select()
    {
        throw new NotImplementedException();
    }

    //Get Administradores
    public List<UsuarioDTO> GetAdministradores()
    {
        try
        {
            var data = _dataBaseContext.Usuarios
                .Include(b => b.Id)
                .Where(b => b.Rol == Entidades.RolName.Administrador)
                .Select(b => new UsuarioDTO
                {
                    Id = b.Id,
                    Nombre = b.Nombre,
                    Apellido = b.Apellido,
                });

            return data.ToList();
        }
        catch (Exception ex)
        {
            throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de administradores: "
                , ex.Message, ex);
        }
    }

    public override AdministradorDTO Select(String id)
    {
        var query = Context().Administradores
            .Where(x => x.Id == id)
            .Select(x => new AdministradorDTO
            {
                Id_Admin = x.Id,
            });
        return query.First();
    }

    public override void Insert(AdministradorDTO administradorDto)
    {
        Administrador administrador = new Administrador();
        administrador.Id = administradorDto.Id_Admin;
        Context().Add(administrador);
        Context().SaveChanges();
    }

    public override void Delete(AdministradorDTO administradorDto)
    {
        var itemToUpdate = Context().Administradores.Find(administradorDto.Id_Admin);
        Context().Administradores.Remove(itemToUpdate);

        Context().Administradores.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Update(AdministradorDTO administradorDto)
    {
        throw new NotImplementedException();
    }
}