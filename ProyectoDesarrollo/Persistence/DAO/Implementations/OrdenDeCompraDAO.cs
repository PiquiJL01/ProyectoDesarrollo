using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class OrdenDeCompraDAO: DAO<OrdenDeCompra>
{
    public OrdenDeCompraDAO(DataBaseContext context) : base(context)
    {
    }

    public override IEnumerable<OrdenDeCompra> Get()
    {
        throw new NotImplementedException();
    }

    public override OrdenDeCompra Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(OrdenDeCompra entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(OrdenDeCompra entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(OrdenDeCompra entity)
    {
        throw new NotImplementedException();
    }
}