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

public class TallerDAO: DAO<TallerDTO>, ITallerDAO
{
    public TallerDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }

    public override List<TallerDTO> Select()
    {
        throw new NotImplementedException();
    }

    //Get Talleres
    public List<TallerDTO> GetTalleres()
    {
        try
        {
            var data = _dataBaseContext.Talleres
                .Include(b => b.Id_Taller)
                .Select(b => new TallerDTO
                {
                    Id_Taller = b.Id_Taller,
                    Name = b.Name,
                    Address = b.Address,
                    PhoneNumber = b.PhoneNumber,
                });

            return data.ToList();
        }
        catch (Exception ex)
        {
            throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                , ex.Message, ex);
        }
    }

    public override TallerDTO Select(string Id_Taller)
    {
        var query = Context().Talleres
            .Where(x => x.Id_Taller == Id_Taller)
            .Select(x => new TallerDTO
            {
                Id_Taller = x.Id_Taller,
                Name = x.Name,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
            });
        return query.First();
    }

    public override void Insert(TallerDTO tallerDto)
    {
        Taller taller = new Taller();
        taller.Id_Taller=tallerDto.Id_Taller;
        taller.Name = tallerDto.Name;
        taller.Address = tallerDto.Address;
        taller.PhoneNumber= tallerDto.PhoneNumber;
        Context().Talleres.Add(taller);
        Context().SaveChanges();
    }

    public override void Update(TallerDTO tallerDto)
    {
        var itemToUpdate = Context().Talleres.Find(tallerDto.Id_Taller);
        itemToUpdate.Name=tallerDto.Name;
        itemToUpdate.Address=tallerDto.Address;
        itemToUpdate.PhoneNumber=tallerDto.PhoneNumber;
        Context().Talleres.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(TallerDTO tallerDto)
    {
        var itemToRemove = Context().Talleres.Find(tallerDto.Id_Taller);
        Context().Talleres.Remove(itemToRemove);
        Context().SaveChanges();
    }
}