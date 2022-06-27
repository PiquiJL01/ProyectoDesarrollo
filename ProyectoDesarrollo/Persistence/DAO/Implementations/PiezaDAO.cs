using ProyectoDesarrollo.Persistence.Entidades;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class PiezaDAO: DAO<Pieza>
{
    public PiezaDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Pieza> Get()
    {
        throw new NotImplementedException();
    }

    public override Pieza Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Pieza entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Pieza entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Pieza entity)
    {
        throw new NotImplementedException();
    }
}