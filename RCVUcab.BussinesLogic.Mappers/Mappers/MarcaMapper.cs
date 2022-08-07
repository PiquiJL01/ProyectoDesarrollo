using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class MarcaMapper
{
    public static MarcaEntity DtoToEntity(MarcaDTO marca)
    {
        return new MarcaEntity
        {
            Name = marca.Name,
            PiezaMarca = PiezaMarcaMapper.ListDtoToEntities(marca.PiezaMarca),
            ProveedorMarca = ProveedorMarcaMapper.ListDtoToEntities(marca.ProveedorMarca),
            Vehiculo = VehiculoMapper.ListDtoToEntities(marca.Vehiculo)
        };
    }

    public static MarcaDTO EntityToDto(MarcaEntity marca)
    {
        return new MarcaDTO
        {
            Name = marca.Name,
            PiezaMarca = PiezaMarcaMapper.ListEntityToDtos(marca.PiezaMarca),
            ProveedorMarca = ProveedorMarcaMapper.ListEntityToDtos(marca.ProveedorMarca),
            Vehiculo = VehiculoMapper.ListEntityToDtos(marca.Vehiculo)
        };
    }

    public static List<MarcaEntity> ListDtoToEntities(ICollection<MarcaDTO> marcas)
    {
        var list = new List<MarcaEntity>();
        foreach (var marcaDto in marcas)
        {
            list.Add(DtoToEntity(marcaDto));
        }
        return list;
    }

    public static List<MarcaDTO> ListEntityToDtos(ICollection<MarcaEntity> marcas)
    {
        var list = new List<MarcaDTO>();
        foreach (var marcaEntity in marcas)
        {
            list.Add(EntityToDto(marcaEntity));
        }

        return list;
    }
}