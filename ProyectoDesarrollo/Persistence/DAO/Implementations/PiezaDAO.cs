using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PiezaDAO: IIncidenteDAO<PiezaDTO>
{

    public PiezaDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }

    public override IEnumerable<PiezaDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override PiezaDTO Select(string ID)
    {
        var query = Context().Piezas
            .Where(p => p.ID == ID)
            .Select(p => new PiezaDTO
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
            });

        return query.First();
    }

    public override void Insert(PiezaDTO piezaDto)
    {
        Pieza pieza = new Pieza();
        pieza.ID = piezaDto.ID;
        pieza.Name = piezaDto.Name;
        pieza.Description = piezaDto.Description;
        Context().Piezas.Add(pieza);
        Context().SaveChanges();
    }

    public override void Update(PiezaDTO piezaDto)
    {
        var itemToUpdate = Context().Piezas.Find(piezaDto.ID);
        itemToUpdate.Name = piezaDto.Name;
        itemToUpdate.Description = piezaDto.Description;

        Context().Piezas.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(PiezaDTO piezaDto)
    {
        var itemToRemove  = Context().Piezas.Find(piezaDto.ID);
        Context().Piezas.Remove(itemToRemove);
        Context().SaveChanges();
    }
}