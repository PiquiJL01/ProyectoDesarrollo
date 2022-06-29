using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PeritoDAO: DAO<PeritoDTO>
{
    public PeritoDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }

    public override IEnumerable<PeritoDTO> Select()
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
}