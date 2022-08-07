using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PiezaMarcaMapper
{
    public static PiezaMarcaEntity DtoToEntity(PiezaMarcaDTO piezaMarca)
    {
        return new PiezaMarcaEntity
        {
            ID = piezaMarca.ID,
            Id_Marca = piezaMarca.Id_Marca,
            Id_Pieza = piezaMarca.Id_Pieza,
            //Marca = MarcaMapper.DtoToEntity(piezaMarca.Marca),
            //Pieza = PiezaMapper.DtoToEntity(piezaMarca.Pieza)
        };
    }

    public static PiezaMarcaDTO EntityToDto(PiezaMarcaEntity piezaMarca)
    {
        return new PiezaMarcaDTO
        {
            ID = piezaMarca.ID,
            Id_Marca = piezaMarca.Id_Marca,
            Id_Pieza = piezaMarca.Id_Pieza,
            //Marca = MarcaMapper.EntityToDto(piezaMarca.Marca),
            //Pieza = PiezaMapper.EntityToDto(piezaMarca.Pieza)
        };
    }

    public static List<PiezaMarcaEntity> ListDtoToEntities(ICollection<PiezaMarcaDTO> piezaMarcas)
    {
        var list = new List<PiezaMarcaEntity>();
        foreach (var piezaMarcaDto in piezaMarcas)
        {
            list.Add(DtoToEntity(piezaMarcaDto));
        }

        return list;
    }

    public static List<PiezaMarcaDTO> ListEntityToDtos(ICollection<PiezaMarcaEntity> piezaMarcas)
    {
        var list = new List<PiezaMarcaDTO>();
        foreach (var piezaMarcaEntity in piezaMarcas)
        {
            list.Add(EntityToDto(piezaMarcaEntity));
        }

        return list;
    }
}