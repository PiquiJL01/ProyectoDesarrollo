using System.Collections.Generic;
using System;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Persistence.DAO;

public class PeritoDAO: DAO<Perito>
{
    public PeritoDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Perito> Get()
    {
        throw new NotImplementedException();
    }

    public override Perito Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Perito entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Perito entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Perito entity)
    {
        throw new NotImplementedException();
    }
}