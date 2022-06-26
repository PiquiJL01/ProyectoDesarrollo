using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO;

public class FacturaDAO: DAO<Factura>
{
    public FacturaDAO(DataBaseContext context) : base(context)
    {
    }

    public override IEnumerable<Factura> Get()
    {
        throw new NotImplementedException();
    }

    public override Factura Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Factura entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Factura entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Factura entity)
    {
        throw new NotImplementedException();
    }
}