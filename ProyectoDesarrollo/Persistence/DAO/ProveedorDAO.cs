using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO;

public class ProveedorDAO: DAO<Proveedor>
{
    public ProveedorDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Proveedor> Get()
    {
        throw new NotImplementedException();
    }

    public override Proveedor Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Proveedor entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Proveedor entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Proveedor entity)
    {
        throw new NotImplementedException();
    }
}