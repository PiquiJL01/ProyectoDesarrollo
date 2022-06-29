using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PolizaDAO: IIncidenteDAO<PolizaDTO>
{
    public PolizaDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }

    public override IEnumerable<PolizaDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override PolizaDTO Select(string ID)
    {
        var query = Context().Polizas
            .Where(p => p.ID == ID)
            .Select(p => new PolizaDTO
            {
                ID = p.ID,
                Id_Admin = p.Id_Admin,
                TipoPoliza = (PolizaDTO.Tipo)p.TipoPoliza
            });
        return query.First();

    }

    public override void Insert(PolizaDTO  polizaDTO)
    {
        Poliza poliza = new Poliza();
        poliza.ID = polizaDTO.ID;
        poliza.Id_Admin = polizaDTO.Id_Admin;
        poliza.TipoPoliza = (Poliza.Tipo)polizaDTO.TipoPoliza;
        Context().Polizas.Add(poliza);
        Context().SaveChanges();
    }

    public override void Update(PolizaDTO polizaDTO)
    {
        var itemToUpdate = Context().Polizas.Find(polizaDTO.ID);
        itemToUpdate.ID = polizaDTO.ID;
        itemToUpdate.Id_Admin = polizaDTO.Id_Admin;
        itemToUpdate.TipoPoliza = (Poliza.Tipo)polizaDTO.TipoPoliza;
        
        Context().Polizas.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(PolizaDTO polizaDto)
    { 
        var  itemToRemove  = Context().Polizas.Find(polizaDto.ID); 
        Context().Polizas.Remove(itemToRemove); 
        Context().SaveChanges();
    }
}