using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class CotizacionDAO : DAO<CotizacionDTO>, ICotizacionDAO
    {

        public CotizacionDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }


        public override List<CotizacionDTO> Select()
        {
            try
            {
                var data = Context().Cotizaciones
                    .Select(c => new CotizacionDTO
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

        public List<CotizacionDTO> GetCotizacionesByID(string id)
        {
            try
            {
                var data = Context().Cotizaciones
                 .Where(c => c.Id == id)
                 .Select(c => new CotizacionDTO
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

        public override CotizacionDTO Select(string id)
        {
            var query = Context().Cotizaciones
                .Where(c => c.Id == id)
                .Select(c => new CotizacionDTO
                {
                    Id = c.Id,
                    MontoTotal = c.MontoTotal,
                    Id_Proveedor = c.Id_Proveedor,
                    Id_Incidente = c.Id_Incidente,
                    Id_Taller = c.Id_Taller,
                });
            return query.First();
        }

        public override void Insert(CotizacionDTO cotizacionDto)
        {
            CotizacionEntity cotizacion = new CotizacionEntity();
            cotizacion.Id = cotizacionDto.Id;
            cotizacion.MontoTotal = cotizacionDto.MontoTotal;
            cotizacion.Id_Proveedor = cotizacionDto.Id_Proveedor;
            cotizacion.Id_Incidente = cotizacionDto.Id_Incidente;
            cotizacion.Id_Taller = cotizacionDto.Id_Taller;
            Context().Cotizaciones.Add(cotizacion);
            Context().SaveChanges();
        }

        public override void Update(CotizacionDTO cotizacionDto)
        {
            var itemToUpdate = Context().Cotizaciones.Find(cotizacionDto.Id);
            itemToUpdate.MontoTotal = cotizacionDto.MontoTotal;

            Context().Cotizaciones.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(CotizacionDTO cotizacionDto)
        {
            var ItemToRemove = Context().Cotizaciones.Find(cotizacionDto.Id);
            Context().Cotizaciones.Remove(ItemToRemove);
            Context().SaveChanges();
        }

        public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente)
        {
            try
            {
                var data = _dataBaseContext.Incidentes
                    .Include(b => b.Cotizacion)
                    .Where(b => b.ID == incidente)
                    .Select(b => new IncidenteDTO
                    {
                        ID = b.ID,
                        Fecha = b.Fecha,
                        Cotizacion = b.Cotizacion.Select(p => new CotizacionDTO
                        {
                            Id = p.Id,
                            MontoTotal = p.MontoTotal,
                            Id_Proveedor = p.Id_Proveedor,
                            Id_Taller = p.Id_Taller,
                            PiezaCotizacion = p.PiezaCotizacion.Select(d => new PiezaCotizacionDTO
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