using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetOrdenDeCompraByIdCommand : Command<List<OrdenDeCompraDTO>>
{
    private string _id;

    public GetOrdenDeCompraByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = OrdenDeCompraDAOFactory.CreateOrdenDeCompraDao();
        SetResult(OrdenDeCompraMapper.ListEntityToDtos(dao.GetOrdenesDeCompraByID(_id)));
    }
}