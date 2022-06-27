using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class UsuarioDAO: DAO<Usuario>
{
    public UsuarioDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override IEnumerable<Usuario> Get()
    {
        throw new NotImplementedException();
    }

    public override Usuario Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Usuario entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Usuario entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Usuario entity)
    {
        throw new NotImplementedException();
    }
}