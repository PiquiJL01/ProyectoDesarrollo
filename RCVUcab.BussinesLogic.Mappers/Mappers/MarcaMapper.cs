using RCVUcab.Persistence.Mappers;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class MarcaMapper
{
    public static MarcaEntity DtoToEntity(MarcaDTO marca)
    {
        if (marca == null)
        {
            return null;
        }

        var listMarca = new List<PiezaMarcaEntity>();
        foreach (var piezaMarcaDto in marca.PiezaMarca)
        {
            listMarca.Add(PiezaMarcaMapper.DtoToEntity(piezaMarcaDto));
        }

        var listProveedorMarca = new List<ProveedorMarcaEntity>();
        foreach (var proveedorMarcaDto in marca.ProveedorMarca)
        {
            listProveedorMarca.Add(ProveedorMarcaMapper.DtoToEntity(proveedorMarcaDto));
        }

        var listVehiculo = new List<VehiculoEntity>();
        foreach (var vehiculoDto in marca.Vehiculo)
        {
            listVehiculo.Add(VehiculoMapper.DtoToEntity(vehiculoDto));
        }

        return new MarcaEntity
        {
            Name = marca.Name,
            PiezaMarca = listMarca,
            ProveedorMarca = listProveedorMarca,
            Vehiculo = listVehiculo
        };
    }

    public static MarcaDTO EntityToDto(MarcaEntity marca)
    {
        if (marca == null)
        {
            return null;
        }

        var listPiezaMarca = new List<PiezaMarcaDTO>();
        foreach (var piezaMarcaEntity in marca.PiezaMarca)
        {
            listPiezaMarca.Add(PiezaMarcaMapper.EntityToDto(piezaMarcaEntity));
        }

        var listProveedorMarca = new List<ProveedorMarcaDTO>();
        foreach (var proveedorMarcaEntity in marca.ProveedorMarca)
        {
            listProveedorMarca.Add(ProveedorMarcaMapper.EntityToDto(proveedorMarcaEntity));
        }

        var listVehiculo = new List<VehiculoDTO>();
        foreach (var vehiculoEntity in marca.Vehiculo)
        {
            listVehiculo.Add(VehiculoMapper.EntityToDto(vehiculoEntity));
        }

        return new MarcaDTO
        {
            Name = marca.Name,
            PiezaMarca = listPiezaMarca,
            ProveedorMarca = listProveedorMarca,
            Vehiculo = listVehiculo
        };
    }
}