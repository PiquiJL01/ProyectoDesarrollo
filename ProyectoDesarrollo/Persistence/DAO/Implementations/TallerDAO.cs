using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;


namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class TallerDAO: DAO<Taller>
{
    public readonly DataBaseContext _dataBaseContext;

    public TallerDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Taller> Get()
    {
        throw new NotImplementedException();
    }

    public  TallerDTO GetTaller(string Id_Taller)
    {
        var query = _dataBaseContext.Talleres
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

    public Task Add(TallerDTO tallerDTO)
    {
        Taller taller = new Taller();
        taller.Id_Taller=tallerDTO.Id_Taller;
        taller.Name = tallerDTO.Name;
        taller.Address = tallerDTO.Address;
        taller.PhoneNumber= tallerDTO.PhoneNumber;
        _dataBaseContext.Talleres.Add(taller);
        _dataBaseContext.SaveChanges();

        return Task.CompletedTask;
    }

    public Task Update(TallerDTO tallerDTO,string Id_Taller)
    {
        var ItemToUpdate = _dataBaseContext.Talleres.Find(Id_Taller);
        ItemToUpdate.Name=tallerDTO.Name;
        ItemToUpdate.Address=tallerDTO.Address;
        ItemToUpdate.PhoneNumber=tallerDTO.PhoneNumber;
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task  Delete(string Id_Taller)
    {
        var ItemToRemove = _dataBaseContext.Talleres.Find(Id_Taller);
        _dataBaseContext.Talleres.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}