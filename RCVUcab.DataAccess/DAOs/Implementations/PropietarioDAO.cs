using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class PropietarioDAO : DAO<PropietarioEntity>, IPropietarioDAO
    {
        public override List<PropietarioEntity> Select()
        {
            try
            {
                var data = Context().Propietarios
                    .Select(x => new PropietarioEntity
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



        public List<PropietarioEntity> GetPropietarioByID(string id)
        {
            try
            {
                var data = Context().Propietarios
                 .Where(x => x.CedulaRif == id)
                 .Select(x => new PropietarioEntity
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

        public override PropietarioEntity Select(string CedulaRif)
        {
            var query = Context().Propietarios
                .Where(x => x.CedulaRif == CedulaRif)
                .Select(x => new PropietarioEntity
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

        public override void Insert(PropietarioEntity propietario)
        {
            Context().Propietarios.Add(propietario);
            Context().SaveChanges();
        }

        public override void Update(PropietarioEntity propietario)
        {
            Context().Propietarios.Update(propietario);
            Context().SaveChanges();
        }

        public override void Delete(PropietarioEntity propietario)
        {
            Context().Propietarios.Remove(propietario);
            Context().SaveChanges();
        }
    }
}