using System;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers
{
    public class TallerMapper
    {
        public static TallerEntity MapDtoToEntity(TallerDTO dto)
        {
            var Taller = new TallerEntity
            {
                ID = dto.ID,
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber
            };
            return Taller;
        }



        public static TallerDTO MapEntityToDto(TallerEntity entity)
        {
            var Taller = new TallerDTO
            {
                ID = entity.ID,
                Name = entity.Name,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber
            };
            return Taller;
        }

        public static List<TallerDTO> MapListEntityToListDto(ICollection<TallerEntity>? Tallers)
        {
            List<TallerDTO> list = new List<TallerDTO>();
            foreach (var Taller in Tallers)
            {
                list.Add(MapEntityToDto(Taller));
            }
            return list;
        }
    }
}

