using ProyectoDesarrollo.Persistence.DataBase;
using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Persistence.DAO;

public class MarcaDAO: DAO<Marca>
{
    public MarcaDAO(DataBaseContext context) : base(context)
    {
    }

    public override IEnumerable<Marca> Get()
    {
        throw new NotImplementedException();
    }

    public override Marca Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Marca entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Marca entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Marca entity)
    {
        throw new NotImplementedException();
    }
}