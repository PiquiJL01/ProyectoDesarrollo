using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PutOrdeDeCompraCommand : Command<OrdenDeCompraDTO>
{
    private OrdenDeCompraDTO _ordenDeCompra;

    public PutOrdeDeCompraCommand(OrdenDeCompraDTO ordenDeCompra)
    {
        _ordenDeCompra = ordenDeCompra;
    }

    public override void Execute()
    {
        var dao = OrdenDeCompraDAOFactory.CreateOrdenDeCompraDao();
        dao.Update(OrdenDeCompraMapper.DtoToEntity(_ordenDeCompra));
        SetResult(_ordenDeCompra);
    }
}