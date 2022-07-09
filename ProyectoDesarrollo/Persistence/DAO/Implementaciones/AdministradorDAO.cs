using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO.Implementaciones
{
    public class AdministradorDAO : IAdministradorDAO
    {
        public readonly DataBaseContext _context;

        public AdministradorDAO(DataBaseContext context)
        {
            _context = context;
        }


        //Get Administradores
        public List<UsuarioDTO> GetAdministradores()
        {
            try
            {
                var data = _context.Usuarios
                   .Include(b => b.Id)
                   .Where(b => b.Rol == Entidades.RolName.Administrador)
                   .Select(b => new UsuarioDTO
                   {
                       Id = b.Id,
                       Nombre = b.Nombre,
                       Apellido = b.Apellido,
                   });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de administradores: "
                , ex.Message, ex);
            }
        }


    }
}

