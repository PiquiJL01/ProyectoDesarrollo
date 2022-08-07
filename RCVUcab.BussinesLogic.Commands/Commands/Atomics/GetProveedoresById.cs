using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetProveedoresById : Command<List<ProveedorDTO>>
{
    private string _id;

    public GetProveedoresById(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = ProveedorDAOFactory.CreateProveedorDao();
        SetResult(ProveedorMapper.ListEntityToDtos(dao.GetProveedoresByID(_id)));
    }
}