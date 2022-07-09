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
    public class TallerDAO : ITallerDAO
    {
        public readonly DataBaseContext _context;

        public TallerDAO(DataBaseContext context)
        {
            _context = context;
        }


        //Get Talleres
        public List<TallerDTO> GetTalleres()
        {
            try
            {
                var data = _context.Talleres
                   .Include(b => b.Id_Taller)
                   .Select(b => new TallerDTO
                   {
                       Id_Taller = b.Id_Taller,
                       Name = b.Name,
                       Address = b.Address,
                       PhoneNumber = b.PhoneNumber,
                   });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                , ex.Message, ex);
            }
        }


    }
}

