using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;
using RCVUcab.Exceptions;

namespace RCVUcab.Persistence.DAOs.Implementations
{

    public class OrdenDeCompraDAO : DAO<OrdenDeCompraDTO>
    {
        public OrdenDeCompraDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<OrdenDeCompraDTO> Select()
        {
            try
            {
                var data = Context().OrdenesDeCompra
                    .Select(b => new OrdenDeCompraDTO
                    {
                        ID = b.ID,
                        Id_Administrador = b.Id_Administrador,

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }


        public List<OrdenDeCompraDTO> GetOrdenesDeCompraByID(string id)
        {
            try
            {
                var data = Context().OrdenesDeCompra
                 .Where(i => i.ID == id)
                 .Select(i => new OrdenDeCompraDTO
                 {
                     ID = i.ID,
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

        public override OrdenDeCompraDTO Select(string id)
        {
            var query = Context().OrdenesDeCompra
                .Where(o => o.ID == id)
                .Select(o => new OrdenDeCompraDTO
                {
                    ID = o.ID,
                    Id_Administrador = o.Id_Administrador,
                });
            return query.First();
        }

        public override void Insert(OrdenDeCompraDTO ordenDeCompraDto)
        {
            OrdenDeCompraEntity ordenDeCompra = new OrdenDeCompraEntity();
            ordenDeCompra.ID = ordenDeCompraDto.ID;
            ordenDeCompra.Id_Administrador = ordenDeCompraDto.Id_Administrador;
            Context().OrdenesDeCompra.Add(ordenDeCompra);
            Context().SaveChanges();

        }

        public override void Update(OrdenDeCompraDTO ordenDeCompraDto)
        {
            var itemToUpdate = Context().OrdenesDeCompra.Find(ordenDeCompraDto.ID);
            itemToUpdate.ID = ordenDeCompraDto.ID;

            Context().OrdenesDeCompra.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(OrdenDeCompraDTO ordenDeCompraDto)
        {
            var itemToRemove = Context().OrdenesDeCompra.Find(ordenDeCompraDto.ID);
            Context().OrdenesDeCompra.Remove(itemToRemove);
            Context().SaveChanges();

        }
    }
}