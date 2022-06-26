using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO;

public class CotizacionDAO: DAO<Cotizacion>
{
    public CotizacionDAO(DataBaseContext context) : base(context)
    {
    }

    public override IEnumerable<Cotizacion> Get()
    {
        throw new NotImplementedException();
    }

    public override Cotizacion Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Cotizacion entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Cotizacion entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Cotizacion entity)
    {
        throw new NotImplementedException();
    }
}