/*using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;
using RCVUcab.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class PropietarioDAO : DAO<PropietarioDTO>, IPropietarioDAO
    {
        public PropietarioDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<PropietarioDTO> Select()
        {
            try
            {
                var data = Context().Propietarios
                    .Select(x => new PropietarioDTO
                    {
                        CedulaRif = x.CedulaRif,
                        PrimerNombre = x.PrimerNombre,
                        SegundoNombre = x.SegundoNombre,
                        PrimerApellido = x.PrimerApellido,
                        SegundoApellido = x.SegundoApellido,
                        FechaNacimiento = x.FechaNacimiento,
                        Direccion = x.Direccion,
                        Id_Poliza = x.Id_Poliza

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }



        public List<PropietarioDTO> GetPropietarioByID(string id)
        {
            try
            {
                var data = Context().Propietarios
                 .Where(x => x.CedulaRif == id)
                 .Select(x => new PropietarioDTO
                 {
                     CedulaRif = x.CedulaRif,
                     PrimerNombre = x.PrimerNombre,
                     SegundoNombre = x.SegundoNombre,
                     PrimerApellido = x.PrimerApellido,
                     SegundoApellido = x.SegundoApellido,
                     FechaNacimiento = x.FechaNacimiento,
                     Direccion = x.Direccion,
                     Id_Poliza = x.Id_Poliza

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Propietario para el: "
                  + id, ex.Message, ex);
            }

        }

        public override PropietarioDTO Select(string CedulaRif)
        {
            var query = Context().Propietarios
                .Where(x => x.CedulaRif == CedulaRif)
                .Select(x => new PropietarioDTO
                {
                    CedulaRif = x.CedulaRif,
                    PrimerNombre = x.PrimerNombre,
                    SegundoNombre = x.SegundoNombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    FechaNacimiento = x.FechaNacimiento,
                    Direccion = x.Direccion,
                    Id_Poliza = x.Id_Poliza
                });
            return query.First();
        }

        public override void Insert(PropietarioDTO propietarioDto)
        {
            PropietarioEntity propietario = new PropietarioEntity();
            propietario.CedulaRif = propietarioDto.CedulaRif;
            propietario.PrimerNombre = propietarioDto.PrimerNombre;
            propietario.SegundoNombre = propietarioDto.SegundoNombre;
            propietario.PrimerApellido = propietarioDto.PrimerApellido;
            propietario.SegundoApellido = propietarioDto.SegundoApellido;
            propietario.FechaNacimiento = propietarioDto.FechaNacimiento;
            propietario.Direccion = propietarioDto.Direccion;
            propietario.Id_Poliza = propietarioDto.Id_Poliza;

            Context().Propietarios.Add(propietario);
            Context().SaveChanges();
        }

        public override void Update(PropietarioDTO propietarioDTO)
        {
            var itemToUpdate = Context().Propietarios.Find(propietarioDTO.CedulaRif);
            itemToUpdate.PrimerNombre = propietarioDTO.PrimerNombre;
            itemToUpdate.SegundoNombre = propietarioDTO.SegundoNombre;
            itemToUpdate.PrimerApellido = propietarioDTO.PrimerApellido;
            itemToUpdate.SegundoApellido = propietarioDTO.SegundoApellido;
            itemToUpdate.Direccion = propietarioDTO.Direccion;
            itemToUpdate.Id_Poliza = propietarioDTO.Id_Poliza;

            Context().Propietarios.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(PropietarioDTO propietarioDto)
        {
            var itemToRemove = Context().Propietarios.Find(propietarioDto.CedulaRif);
            Context().Propietarios.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}*/