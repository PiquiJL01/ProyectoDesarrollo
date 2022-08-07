using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetProveedoresCommand : Command<List<ProveedorDTO>>
{
    public override void Execute()
    {
        var dao = ProveedorDAOFactory.CreateProveedorDao();
        SetResult(ProveedorMapper.ListEntityToDtos(dao.Select()));
    }
}