using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers
{
    public class ProveedorMapper
    {
        public static ProveedorEntity MapDtoToEntity(ProveedorDTO dto)
        {
            var Proveedor = new ProveedorEntity
            {
                ID = dto.Id_Proveedor,
                Name = dto.Name,
                Address = dto.Address
            };
            return Proveedor;
        }



        public static ProveedorDTO MapEntityToDto(ProveedorEntity entity)
        {
            var Proveedor = new ProveedorDTO
            {
                Id_Proveedor = entity.ID,
                Name = entity.Name,
                Address = entity.Address
            };
            return Proveedor;
        }

        public static List<ProveedorDTO> MapListEntityToListDto(ICollection<ProveedorEntity>? Proveedors)
        {
            List<ProveedorDTO> list = new List<ProveedorDTO>();
            foreach (var Proveedor in Proveedors)
            {
                list.Add(MapEntityToDto(Proveedor));
            }
            return list;
        }
    }
}

