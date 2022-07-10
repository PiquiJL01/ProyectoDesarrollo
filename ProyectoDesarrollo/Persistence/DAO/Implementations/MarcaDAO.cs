using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;
using ProyectoDesarrollo.Persistence.Data;


namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class MarcaDAO: DAO<MarcaDTO>
{
    public MarcaDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    }

    public override List<MarcaDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override MarcaDTO Select(string name)
    {
        var query =Context().Marcas
            .Where(m => m.Name == name)
            .Select(m => new MarcaDTO 
            { 
                Name = m.Name 
            });
        return query.First();
    }

    public override void Insert(MarcaDTO marcaDto)
    {
        Marca marca =  new Marca();
        marca.Name = marcaDto.Name;
        Context().Marcas.Add(marca);
        Context().SaveChanges();
    }

    public override void Update(MarcaDTO marcaDto)
    {
        var itemToUpdate = Context().Marcas.Find(marcaDto.Name);
        itemToUpdate.Name = marcaDto.Name;

        Context().Marcas.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(MarcaDTO marcaDto)
    {
        var itemToRemove = Context().Marcas.Find(marcaDto.Name);
        Context().Marcas.Remove(itemToRemove);
        Context().SaveChanges();
    }
}