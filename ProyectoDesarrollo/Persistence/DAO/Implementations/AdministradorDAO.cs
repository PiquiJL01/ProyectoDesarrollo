using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class AdministradorDAO : DAO<AdministradorDTO>
{

    public AdministradorDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    } 

      
 public override IEnumerable<AdministradorDTO> Select()
    {
        throw new NotImplementedException();
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