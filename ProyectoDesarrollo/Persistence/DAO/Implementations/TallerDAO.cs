using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class TallerDAO: DAO<Taller>
{
    public TallerDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Taller> Get()
    {
        throw new NotImplementedException();
    }

    public override Taller Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Taller entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Taller entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Taller entity)
    {
        throw new NotImplementedException();
    }
}