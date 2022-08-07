using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetProveedorCommand : Command<ProveedorDTO>
{
    private string _id;

    public GetProveedorCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = ProveedorDAOFactory.CreateProveedorDao();
        SetResult(ProveedorMapper.EntityToDto(dao.Select(_id)));
    }
}