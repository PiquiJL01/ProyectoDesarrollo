using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class AdministradorDAO :DAO<Administrador>
{
    public AdministradorDAO(DataBaseContext context) : base(context)
    {
    }

    public override IEnumerable<Administrador> Get()
    {
        throw new NotImplementedException();
    }

    public override Administrador Get(string id)
    {
        throw new NotImplementedException();
    }

    public override void Post(Administrador entity)
    {
        throw new NotImplementedException();
    }

    public override void Put(Administrador entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Administrador entity)
    {
        throw new NotImplementedException();
    }
}