namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PiezaMarcaMapper
{
    public static PiezaMarcaEntity DtoToEntity(PiezaMarcaDTO piezaMarca)
    {
        if (piezaMarca == null)
        {
            return null;
        }

        return new PiezaMarcaEntity
        {
            ID = piezaMarca.ID,
            Id_Marca = piezaMarca.Id_Marca,
            Id_Pieza = piezaMarca.Id_Pieza,
            Marca = MarcaMapper.DtoToEntity(piezaMarca.Marca),
            Pieza = PiezaMapper.DtoToEntity(piezaMarca.Pieza)
        };
    }

    public static PiezaMarcaDTO EntityToDto(PiezaMarcaEntity piezaMarca)
    {
        if (piezaMarca == null)
        {
            return null;
        }

        return new PiezaMarcaDTO
        {
            ID = piezaMarca.ID,
            Id_Marca = piezaMarca.Id_Marca,
            Id_Pieza = piezaMarca.Id_Pieza,
            Marca = MarcaMapper.EntityToDto(piezaMarca.Marca),
            Pieza = PiezaMapper.EntityToDto(piezaMarca.Pieza)
        };
    }
}