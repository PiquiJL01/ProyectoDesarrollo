using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class CotizacionDAO : DAO<CotizacionEntity>, ICotizacionDAO
    {
        public override List<CotizacionEntity> Select()
        {
            try
            {
                var data = Context().Cotizaciones
                    .Select(c => new CotizacionEntity()
                    {
                        Id = c.Id,
                        MontoTotal = c.MontoTotal,
                        Id_Proveedor = c.Id_Proveedor,
                        Id_Incidente = c.Id_Incidente,
                        Id_Taller = c.Id_Taller,

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public List<CotizacionEntity> GetCotizacionesByID(string id)
        {
            try
            {
                var data = Context().Cotizaciones
                 .Where(c => c.Id == id)
                 .Select(c => new CotizacionEntity()
                 {
                     Id = c.Id,
                     MontoTotal = c.MontoTotal,
                     Id_Proveedor = c.Id_Proveedor,
                     Id_Incidente = c.Id_Incidente,
                     Id_Taller = c.Id_Taller,

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override CotizacionEntity Select(string id)
        {
            var query = Context().Cotizaciones
                .Where(c => c.Id == id)
                .Select(c => new CotizacionEntity()
                {
                    Id = c.Id,
                    MontoTotal = c.MontoTotal,
                    Id_Proveedor = c.Id_Proveedor,
                    Id_Incidente = c.Id_Incidente,
                    Id_Taller = c.Id_Taller,
                });
            return query.First();
        }

        public override void Insert(CotizacionEntity cotizacion)
        {
            Context().Cotizaciones.Add(cotizacion);
            Context().SaveChanges();
        }

        public override void Update(CotizacionEntity cotizacion)
        {
            var itemToUpdate = Context().Cotizaciones.Find(cotizacion.Id);
            itemToUpdate.MontoTotal = cotizacion.MontoTotal;

            Context().Cotizaciones.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(CotizacionEntity cotizacion)
        {
            var ItemToRemove = Context().Cotizaciones.Find(cotizacion.Id);
            Context().Cotizaciones.Remove(ItemToRemove);
            Context().SaveChanges();
        }

        public List<IncidenteEntity> GetCotizacionesByIncidente(string incidente)
        {
            try
            {
                var data = _dataBaseContext.Incidentes
                    .Include(b => b.Cotizacion)
                    .Where(b => b.ID == incidente)
                    .Select(b => new IncidenteEntity
                    {
                        ID = b.ID,
                        Fecha = b.Fecha,
                        Cotizacion = b.Cotizacion.Select(p => new CotizacionEntity()
                        {
                            Id = p.Id,
                            MontoTotal = p.MontoTotal,
                            Id_Proveedor = p.Id_Proveedor,
                            Id_Taller = p.Id_Taller,
                            PiezaCotizacion = p.PiezaCotizacion.Select(d => new PiezaCotizacionEntity
                            {
                                Id_Pieza = d.Id_Pieza,


                            }).ToList(),

                        }).ToList()
                    });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Cotizaciones: "
                    , ex.Message, ex);
            }
        }
    }
}