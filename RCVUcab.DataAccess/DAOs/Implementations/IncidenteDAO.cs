using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class IncidenteDAO : DAO<IncidenteEntity>, IIncidenteDAO
    {
        public override List<IncidenteEntity> Select()
        {
            try
            {
                var data = Context().Incidentes
                    .Select(i => new IncidenteEntity
                    {
                        ID = i.ID,
                        Ubicacion = i.Ubicacion,
                        Fecha = i.Fecha,
                        Id_Perito = i.Id_Perito,
                        Id_Administrador = i.Id_Administrador,

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public override IncidenteEntity Select(string id)
        {
            var query = Context().Incidentes
                .Where(i => i.ID == id)
                .Select(i => new IncidenteEntity
                {
                    ID = i.ID,
                    Ubicacion = i.Ubicacion,
                    Fecha = i.Fecha,
                    Id_Perito = i.Id_Perito,
                    Id_Administrador = i.Id_Administrador,

                });
            return query.First();
        }

        public List<IncidenteEntity> GetIncidenteByID(string id)
        {
            try
            {
                var data = Context().Incidentes
                 .Where(i => i.ID == id)
                 .Select(i => new IncidenteEntity
                 {
                     ID = i.ID,
                     Ubicacion = i.Ubicacion,
                     Fecha = i.Fecha,
                     Id_Perito = i.Id_Perito,
                     Id_Administrador = i.Id_Administrador,

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override void Insert(IncidenteEntity incidente)
        {
            Context().Incidentes.Add(incidente);
            Context().SaveChanges();
        }

        public override void Update(IncidenteEntity incidente)
        {
            Context().Incidentes.Update(incidente);
            Context().SaveChanges();
        }

        public override void Delete(IncidenteEntity incidenteDto)
        {
            var itemToRemove = Context().Incidentes.Find(incidenteDto.ID);
            Context().Incidentes.Remove(itemToRemove);
            Context().SaveChanges();
        }

        //Get Incidentes - PROBADO
        public List<IncidenteEntity> GetIncidentesByAdministrador(string administrador)
        {
            var data = _dataBaseContext.Incidentes
                .Where(b => b.Id_Administrador == administrador)
                .Select(b => new IncidenteEntity 
                { 
                    Id_Administrador = administrador, 
                    ID = b.ID, 
                    Ubicacion = b.Ubicacion, 
                    Fecha = b.Fecha, 
                    Id_Perito = b.Id_Perito
                }); 
            
            return data.ToList();
        }
    }
}