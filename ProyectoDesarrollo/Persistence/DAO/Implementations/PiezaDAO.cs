using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PiezaDAO: DAO<Pieza>
{
    public readonly DataBaseContext _dataBaseContext;

    public PiezaDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<Pieza> Get()
    {
        throw new NotImplementedException();
    }

    public PiezaDTO GetPieza(string ID)
    {
        var query = _dataBaseContext.Piezas
            .Where(p => p.ID == ID)
            .Select(p => new PiezaDTO
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
            });
        return query.First();
    }

    public Task Add(PiezaDTO  piezaDTO)
    {
        Pieza pieza = new Pieza();
        pieza.ID = piezaDTO.ID;
        pieza.Name = piezaDTO.Name;
        pieza.Description = piezaDTO.Description;
        _dataBaseContext.Piezas.Add(pieza);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Update(PiezaDTO piezaDTO,string  ID)
    {
        var ItemToUpdate = _dataBaseContext.Piezas.Find(ID);
        ItemToUpdate.Name = piezaDTO.Name;
        ItemToUpdate.Description = piezaDTO.Description;
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string ID)
    {
        var ItemToRemove  = _dataBaseContext.Piezas.Find(ID);
        _dataBaseContext.Piezas.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}