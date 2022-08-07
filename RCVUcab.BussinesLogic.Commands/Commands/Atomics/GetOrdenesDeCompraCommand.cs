using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetOrdenesDeCompraCommand : Command<List<OrdenDeCompraDTO>>
{
    public override void Execute()
    {
        var dao = OrdenDeCompraDAOFactory.CreateOrdenDeCompraDao();
        SetResult(OrdenDeCompraMapper.ListEntityToDtos(dao.Select()));
    }
}