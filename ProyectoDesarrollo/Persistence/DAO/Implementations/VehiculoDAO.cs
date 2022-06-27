using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class VehiculoDAO: DAO<Vehiculo>
{
    public VehiculoDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Vehiculo> Get()
    {
        throw new NotImplementedException();
    }

    public override Vehiculo Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Vehiculo entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Vehiculo entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Vehiculo entity)
    {
        throw new NotImplementedException();
    }
}