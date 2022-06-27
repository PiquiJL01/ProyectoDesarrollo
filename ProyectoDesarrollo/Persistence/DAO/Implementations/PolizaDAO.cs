using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PolizaDAO: DAO<Poliza>
{
    public PolizaDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Poliza> Get()
    {
        throw new NotImplementedException();
    }

    public override Poliza Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Poliza entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Poliza entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Poliza entity)
    {
        throw new NotImplementedException();
    }
}