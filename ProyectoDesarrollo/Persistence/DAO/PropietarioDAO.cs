using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO;

public class PropietarioDAO: DAO<Propietario>
{
    public PropietarioDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Propietario> Get()
    {
        throw new NotImplementedException();
    }

    public override Propietario Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Propietario entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Propietario entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Propietario entity)
    {
        throw new NotImplementedException();
    }
}