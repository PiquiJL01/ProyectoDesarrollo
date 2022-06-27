using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;


public class IncidenteDAO: DAO<Incidente>
{
    public IncidenteDAO(DataBaseContext context) : base(context)
    {
    }

    public override IEnumerable<Incidente> Get()
    {
        throw new NotImplementedException();
    }

    public override Incidente Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Incidente entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Incidente entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Incidente entity)
    {
        throw new NotImplementedException();
    }
}