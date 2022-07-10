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

public class PeritoDAO: DAO<PeritoDTO>, IPeritoDAO
{
    public PeritoDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }

    public override List<PeritoDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override PeritoDTO Select(string id)
    {
        var query = Context().Peritos
            .Where(p => p.Id == id)
            .Select(p => new PeritoDTO
            {
                Id_Perito = p.Id_Perito           
            });
        return query.First();

    }

    public override void Insert(PeritoDTO peritoDto)
    {
        Perito  perito = new Perito();
        perito.Id_Perito = peritoDto.Id_Perito;
        Context().Peritos.Add(perito);
        Context().SaveChanges();
    }

    public override void Update(PeritoDTO peritoDto)
    {
        var itemToUpdate = Context().Peritos.Find(peritoDto.Id_Perito);
        itemToUpdate.Id_Perito = peritoDto.Id_Perito;

        Context().Peritos.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(PeritoDTO peritoDto)
    {
        var ItemToRemove  = Context().Peritos.Find(peritoDto.Id_Perito);
        Context().Peritos.Remove(ItemToRemove);
        Context().SaveChanges();
    }

    //Get Peritoes
    public List<UsuarioDTO> GetPeritos()
    {
        try
        {
            var data = _dataBaseContext.Usuarios
                .Include(b => b.Id)
                .Where(b => b.Rol == Entidades.RolName.Perito)
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
            throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de Peritos: "
                , ex.Message, ex);
        }
    }
}